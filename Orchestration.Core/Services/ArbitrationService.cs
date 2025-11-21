using Microsoft.EntityFrameworkCore;
using Orchestration.Core.DTOs;
using Orchestration.Core.Models;
using Orchestration.Data;
using Orchestration.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Core.Services
{
    public class ArbitrationService : IArbitrationService
    {
        private readonly ApplicationDbContext _dbContext;

        public ArbitrationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ArbitrationResult?> ChooseModelAsync(string taskType)
        {
            try
            {
                // Get all active models for the given task type, ordered by priority
                var models = await _dbContext.AIModels
                    .Include(m => m.Provider)
                    .Where(m => m.TaskType.ToLower() == taskType.ToLower() && m.IsActive)
                    .OrderBy(m => m.Priority)
                    .ToListAsync();

                if (!models.Any())
                    return null;

                // Try primary first, then failover to backups
                foreach (var model in models)
                {
                    bool success = await TryProviderAsync(model);
                    if (success)
                    {
                        return new ArbitrationResult
                        {
                            ModelName = model.Name,
                            ProviderName = model.Provider.Name,
                            TaskType = model.TaskType,
                            ApiEndpoint = model.ApiEndpoint,
                            Capabilities = model.Capabilities,
                            Version = model.Version,
                            CostPerToken = model.CostPerToken,
                            Priority = model.Priority,
                            IsActive = model.IsActive
                        };
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ArbitrationResult?> ChooseModelCapabilityAwareAsync(string taskType, string requiredCapability)
        {
            var models = await _dbContext.AIModels
                .Include(m => m.Provider)
                .Where(m => m.TaskType.ToLower() == taskType.ToLower()
                            && m.IsActive
                            && m.Capabilities.ToLower().Contains(requiredCapability.ToLower()))
                .OrderBy(m => m.Priority)
                .ToListAsync();

            foreach (var model in models)
            {
                if (await TryProviderAsync(model))
                    return MapToResult(model);
            }

            return null;
        }

        private ArbitrationResult MapToResult(AIModel model)
        {
            return new ArbitrationResult
            {
                ModelName = model.Name,
                ProviderName = model.Provider.Name,
                TaskType = model.TaskType,
                ApiEndpoint = model.ApiEndpoint,
                Capabilities = model.Capabilities,
                Version = model.Version,
                CostPerToken = model.CostPerToken,
                Priority = model.Priority,
                IsActive = model.IsActive
            };
        }

        // Simulated provider call (replace with actual API integration later)
        private async Task<bool> TryProviderAsync(AIModel model)
        {
            await Task.Delay(100); // simulate latency
                                   // For now, randomly simulate success/failure
            return new Random().Next(0, 2) == 0;
        }

        public async Task<List<AIModel>> GetAvailableModelsAsync()
        {
            return await _dbContext.AIModels
                .Include(m => m.Provider)
                .Where(m => m.IsActive)
                .ToListAsync();
        }

        public async Task<ArbitrationResult?> ChooseModelCostAwareAsync(string taskType)
        {
            var models = await _dbContext.AIModels
                .Include(m => m.Provider)
                .Where(m => m.TaskType.ToLower() == taskType.ToLower() && m.IsActive)
                .OrderBy(m => m.CostPerToken)
                .ThenBy(m => m.Priority)
                .ToListAsync();

            foreach (var model in models)
            {
                if (await TryProviderAsync(model))
                    return MapToResult(model);
            }

            return null;
        }

        public async Task UpdateModelHealthAsync(AIModel model)
        {
            try
            {
                // Simulate health check (replace with actual API ping)
                bool reachable = await PingProviderAsync(model.ApiEndpoint);

                model.IsActive = reachable;
                model.UpdatedAt = DateTime.UtcNow;
                _dbContext.AIModels.Update(model);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                model.IsActive = false;
                model.UpdatedAt = DateTime.UtcNow;
                _dbContext.AIModels.Update(model);
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task<bool> PingProviderAsync(string endpoint)
        {
            await Task.Delay(50); // simulate latency
            return new Random().Next(0, 10) > 2; // 80% chance "healthy"
        }

        public async Task<ArbitrationResult?> ChooseModelUnifiedAsync(string taskType, string requiredCapability, decimal maxCostPerToken = decimal.MaxValue)
        {
            var models = await _dbContext.AIModels
                .Include(m => m.Provider)
                .Where(m => m.TaskType.ToLower() == taskType.ToLower()
                    && m.IsActive
                    && m.HealthStatus == HealthStatus.Healthy
                    && m.Capabilities.ToLower().Contains(requiredCapability.ToLower())
                    && m.CostPerToken <= maxCostPerToken)
                .OrderBy(m => m.CostPerToken)
                .ThenBy(m => m.Priority)
                .ToListAsync();

            foreach (var model in models)
            {
                if (await TryProviderAsync(model))
                    return MapToResult(model);
            }

            return null;
        }

        public async Task<ArbitrationResult?> ChooseModelWithPoliciesAsync(ArbitrationContext ctx)
        {
            // 1) Base candidate set
            var candidates = await _dbContext.AIModels
                .Include(m => m.Provider)
                .Where(m => m.TaskType.ToLower() == ctx.TaskType.ToLower() && m.IsActive)
                .ToListAsync();

            // 2) Apply constraints (hard filters)
            foreach (var p in ctx.Policies)
            {
                // Overrides first
                if (!string.IsNullOrEmpty(p.PinModelName))
                {
                    var pinned = candidates.FirstOrDefault(m => m.Name.Equals(p.PinModelName, StringComparison.OrdinalIgnoreCase));
                    if (pinned != null) return MapToResult(pinned);
                }
                if (!string.IsNullOrEmpty(p.PinProviderName))
                {
                    var pinned = candidates.FirstOrDefault(m => m.Provider.Name.Equals(p.PinProviderName, StringComparison.OrdinalIgnoreCase));
                    if (pinned != null) return MapToResult(pinned);
                }

                // Hard filters
                if (p.RequireHealthyOnly)
                    candidates = candidates.Where(m => m.HealthStatus == HealthStatus.Healthy).ToList();

                if (p.MaxCostPerToken.HasValue)
                    candidates = candidates.Where(m => m.CostPerToken <= p.MaxCostPerToken.Value).ToList();

                if (ctx.MaxCostPerToken.HasValue) // request-level constraint
                    candidates = candidates.Where(m => m.CostPerToken <= ctx.MaxCostPerToken.Value).ToList();

                if (p.RequireCapabilities.Count > 0)
                    candidates = candidates.Where(m =>
                        p.RequireCapabilities.All(req => m.Capabilities.Contains(req, StringComparison.OrdinalIgnoreCase))).ToList();

                if (ctx.RequiredCapabilities.Count > 0)
                    candidates = candidates.Where(m =>
                        ctx.RequiredCapabilities.All(req => m.Capabilities.Contains(req, StringComparison.OrdinalIgnoreCase))).ToList();

                if (p.AllowedProviders.Count > 0)
                    candidates = candidates.Where(m => p.AllowedProviders.Contains(m.Provider.Name)).ToList();

                if (p.DeniedProviders.Count > 0)
                    candidates = candidates.Where(m => !p.DeniedProviders.Contains(m.Provider.Name)).ToList();

                if (p.AllowedRegions.Count > 0)
                    candidates = candidates.Where(m => string.IsNullOrEmpty(m.Regions)
                        ? false
                        : p.AllowedRegions.Any(r => m.Regions.Contains(r, StringComparison.OrdinalIgnoreCase))).ToList();

                if (p.RequireComplianceTags.Count > 0)
                    candidates = candidates.Where(m =>
                        (m.Provider.ComplianceTags != ComplianceTag.None &&
                         p.RequireComplianceTags.All(tag =>
                             m.Provider.ComplianceTags.ToString().Contains(tag, StringComparison.OrdinalIgnoreCase)))
                    ).ToList();

                if (!candidates.Any()) break; // early exit if nothing remains
            }

            if (!candidates.Any()) return null;

            // 3) Scoring (soft preferences)
            IEnumerable<AIModel> ranked = candidates;

            foreach (var p in ctx.Policies)
            {
                ranked = ranked
                    .OrderBy(m => p.PreferLowerCost ? m.CostPerToken : 0)
                    .ThenByDescending(m => p.PreferHigherSuccessRate ? (m.SuccessRate ?? 0m) : 0)
                    .ThenBy(m => p.PreferLowerLatency ? (m.AvgLatencyMs ?? int.MaxValue) : int.MaxValue)
                    .ThenBy(m => p.PreferEnterpriseTrust && m.Provider.TrustLevel == TrustLevel.Enterprise ? 0 : 1)
                    .ThenBy(m => m.Priority); // stable fallback
            }

            // 4) Attempt models in ranked order with failover
            foreach (var model in ranked)
            {
                if (await TryProviderAsync(model))
                    return MapToResult(model);
            }

            return null;
        }
    }
}
