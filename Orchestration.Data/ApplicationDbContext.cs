using Orchestration.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Orchestration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; } 
        public DbSet<Provider> Providers { get; set; }
        public DbSet<AIModel> AIModels { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<OrchestrationLog> OrchestrationLogs { get; set; } // For logging orchestration requests

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Provider>().HasData(
                new Provider { Id = 5, Name = "Meta AI", Vendor = "Meta", Website = "https://ai.meta.com", IsActive = true, TrustLevel = TrustLevel.Standard, ComplianceTags = ComplianceTag.SOC2 | ComplianceTag.ISO27001 | ComplianceTag.GDPR, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
                new Provider { Id = 6, Name = "Mistral AI", Vendor = "Mistral", Website = "https://mistral.ai", IsActive = true, TrustLevel = TrustLevel.Standard, ComplianceTags = ComplianceTag.None, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
                new Provider { Id = 4, Name = "HuggingFace", Vendor = "HuggingFace", Website = "https://huggingface.co", IsActive = true, TrustLevel = TrustLevel.Standard, ComplianceTags = ComplianceTag.None, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
                new Provider { Id = 7, Name = "Cohere", Vendor = "Cohere", Website = "https://cohere.com", IsActive = true, TrustLevel = TrustLevel.Standard, ComplianceTags = ComplianceTag.SOC2 | ComplianceTag.ISO27001, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
                new Provider { Id = 8, Name = "AI21 Labs", Vendor = "AI21 Labs", Website = "https://ai21.com", IsActive = true, TrustLevel = TrustLevel.Standard, ComplianceTags = ComplianceTag.SOC2 | ComplianceTag.ISO27001, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) }
            );

            modelBuilder.Entity<AIModel>().HasData(
                // Meta
                new AIModel { Id = 6, ProviderId = 5, Name = "LLaMA 3", TaskType = "reasoning", ApiEndpoint = "https://api.meta.com/v1/llama3", Priority = 1, IsActive = true, Version = "v3.0", Capabilities = "text, reasoning", CostPerToken = 0.006M, Regions = "us-east, eu-west", SuccessRate = 0.93M, AvgLatencyMs = 135, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },

                // Mistral
                new AIModel { Id = 7, ProviderId = 6, Name = "Mistral 7B", TaskType = "reasoning", ApiEndpoint = "https://api.mistral.ai/v1/mistral7b", Priority = 1, IsActive = true, Version = "7B", Capabilities = "lightweight text generation", CostPerToken = 0.003M, Regions = "eu-west", SuccessRate = 0.91M, AvgLatencyMs = 125, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
                new AIModel { Id = 8, ProviderId = 6, Name = "Mixtral 8x7B", TaskType = "reasoning", ApiEndpoint = "https://api.mistral.ai/v1/mixtral", Priority = 2, IsActive = true, Version = "8x7B", Capabilities = "mixture of experts", CostPerToken = 0.004M, Regions = "eu-west", SuccessRate = 0.90M, AvgLatencyMs = 145, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },

                // HuggingFace
                new AIModel { Id = 9, ProviderId = 4, Name = "BLOOM", TaskType = "reasoning", ApiEndpoint = "https://api.huggingface.co/v1/bloom", Priority = 1, IsActive = true, Version = "v1.0", Capabilities = "multilingual text generation", CostPerToken = 0.005M, Regions = "global", SuccessRate = 0.89M, AvgLatencyMs = 170, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },
                new AIModel { Id = 10, ProviderId = 4, Name = "Falcon", TaskType = "reasoning", ApiEndpoint = "https://api.huggingface.co/v1/falcon", Priority = 2, IsActive = true, Version = "v1.0", Capabilities = "text generation", CostPerToken = 0.004M, Regions = "global", SuccessRate = 0.88M, AvgLatencyMs = 165, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },

                // Cohere
                new AIModel { Id = 11, ProviderId = 7, Name = "Command R+", TaskType = "retrieval-augmented", ApiEndpoint = "https://api.cohere.ai/v1/command-r-plus", Priority = 1, IsActive = true, Version = "R+", Capabilities = "RAG, text generation", CostPerToken = 0.015M, Regions = "us-east, eu-west", SuccessRate = 0.92M, AvgLatencyMs = 155, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) },

                // AI21 Labs
                new AIModel { Id = 12, ProviderId = 8, Name = "Jurassic-2", TaskType = "text-generation", ApiEndpoint = "https://api.ai21.com/v1/jurassic2", Priority = 1, IsActive = true, Version = "v2.0", Capabilities = "text generation", CostPerToken = 0.012M, Regions = "us-east, eu-west", SuccessRate = 0.91M, AvgLatencyMs = 150, HealthStatus = HealthStatus.Healthy, CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
