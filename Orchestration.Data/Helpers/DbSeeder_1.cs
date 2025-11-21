using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Orchestration.Data.Entities;

namespace Orchestration.Data.Helpers
{
    public static class DbSeeder_1
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // Ensure database is created and migrated
            await db.Database.GetService<IMigrator>().MigrateAsync();

            // === Providers ===
            if (!db.Providers.Any(p => p.Name == "OpenAI"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 1,
                    Name = "OpenAI",
                    Vendor = "OpenAI",
                    Website = "https://openai.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Enterprise,
                    ComplianceTags = ComplianceTag.SOC2 | ComplianceTag.ISO27001 | ComplianceTag.GDPR,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Meta AI"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 5,
                    Name = "Meta AI",
                    Vendor = "Meta",
                    Website = "https://ai.meta.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.SOC2 | ComplianceTag.ISO27001 | ComplianceTag.GDPR,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                });
            }

            // === AIModels ===
            if (!db.AIModels.Any(m => m.Name == "GPT-5"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 1,
                    ProviderId = 1,
                    Name = "GPT-5",
                    TaskType = "reasoning",
                    ApiEndpoint = "https://api.openai.com/v1/gpt5",
                    Priority = 1,
                    IsActive = true,
                    Version = "v5.0",
                    Capabilities = "text, reasoning, multimodal",
                    CostPerToken = 0.020M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.98M,
                    AvgLatencyMs = 120,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "LLaMA 3"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 6,
                    ProviderId = 5,
                    Name = "LLaMA 3",
                    TaskType = "reasoning",
                    ApiEndpoint = "https://api.meta.com/v1/llama3",
                    Priority = 1,
                    IsActive = true,
                    Version = "v3.0",
                    Capabilities = "text, reasoning",
                    CostPerToken = 0.006M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.93M,
                    AvgLatencyMs = 135,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                });
            }

            await db.SaveChangesAsync();
        }
    }

    public static class Batch3ASeeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // === Providers ===
            if (!db.Providers.Any(p => p.Name == "Stability AI"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 9,
                    Name = "Stability AI",
                    Vendor = "Stability AI",
                    Website = "https://stability.ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.None,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Midjourney"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 14,
                    Name = "Midjourney",
                    Vendor = "Midjourney",
                    Website = "https://midjourney.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Experimental,
                    ComplianceTags = ComplianceTag.None,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Black Forest Labs"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 15,
                    Name = "Black Forest Labs",
                    Vendor = "Black Forest Labs",
                    Website = "https://blackforestlabs.ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Experimental,
                    ComplianceTags = ComplianceTag.ResearchUse,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "xAI"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 13,
                    Name = "xAI",
                    Vendor = "xAI",
                    Website = "https://x.ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.None,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "DeepSeek"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 12,
                    Name = "DeepSeek",
                    Vendor = "DeepSeek",
                    Website = "https://deepseek.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.ResearchUse,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            // === Models (first half) ===
            if (!db.AIModels.Any(m => m.Name == "StableLM"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 19,
                    ProviderId = 9,
                    Name = "StableLM",
                    TaskType = "reasoning",
                    ApiEndpoint = "https://api.stability.ai/v1/stablelm",
                    Priority = 1,
                    IsActive = true,
                    Version = "v1.0",
                    Capabilities = "text generation",
                    CostPerToken = 0.007M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.90M,
                    AvgLatencyMs = 150,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "Stable Diffusion XL"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 20,
                    ProviderId = 9,
                    Name = "Stable Diffusion XL",
                    TaskType = "image-generation",
                    ApiEndpoint = "https://api.stability.ai/v1/stablediffusionxl",
                    Priority = 1,
                    IsActive = true,
                    Version = "XL",
                    Capabilities = "image generation",
                    CostPerToken = 0.050M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.92M,
                    AvgLatencyMs = 180,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "Midjourney v6"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 26,
                    ProviderId = 14,
                    Name = "Midjourney v6",
                    TaskType = "image-generation",
                    ApiEndpoint = "https://api.midjourney.com/v1/v6",
                    Priority = 1,
                    IsActive = true,
                    Version = "v6",
                    Capabilities = "image generation",
                    CostPerToken = 0.045M,
                    Regions = "global",
                    SuccessRate = 0.93M,
                    AvgLatencyMs = 200,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            await db.SaveChangesAsync();
        }
    }

    public static class Batch3Seeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // === Providers ===
            if (!db.Providers.Any(p => p.Name == "Stability AI"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 9,
                    Name = "Stability AI",
                    Vendor = "Stability AI",
                    Website = "https://stability.ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.None,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Midjourney"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 14,
                    Name = "Midjourney",
                    Vendor = "Midjourney",
                    Website = "https://midjourney.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Experimental,
                    ComplianceTags = ComplianceTag.None,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Black Forest Labs"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 15,
                    Name = "Black Forest Labs",
                    Vendor = "Black Forest Labs",
                    Website = "https://blackforestlabs.ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Experimental,
                    ComplianceTags = ComplianceTag.ResearchUse,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "xAI"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 13,
                    Name = "xAI",
                    Vendor = "xAI",
                    Website = "https://x.ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.None,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "DeepSeek"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 12,
                    Name = "DeepSeek",
                    Vendor = "DeepSeek",
                    Website = "https://deepseek.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Standard,
                    ComplianceTags = ComplianceTag.ResearchUse,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            // === Models (first half) ===
            if (!db.AIModels.Any(m => m.Name == "StableLM"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 19,
                    ProviderId = 9,
                    Name = "StableLM",
                    TaskType = "reasoning",
                    ApiEndpoint = "https://api.stability.ai/v1/stablelm",
                    Priority = 1,
                    IsActive = true,
                    Version = "v1.0",
                    Capabilities = "text generation",
                    CostPerToken = 0.007M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.90M,
                    AvgLatencyMs = 150,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "Stable Diffusion XL"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 20,
                    ProviderId = 9,
                    Name = "Stable Diffusion XL",
                    TaskType = "image-generation",
                    ApiEndpoint = "https://api.stability.ai/v1/stablediffusionxl",
                    Priority = 1,
                    IsActive = true,
                    Version = "XL",
                    Capabilities = "image generation",
                    CostPerToken = 0.050M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.92M,
                    AvgLatencyMs = 180,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "Midjourney v6"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 26,
                    ProviderId = 14,
                    Name = "Midjourney v6",
                    TaskType = "image-generation",
                    ApiEndpoint = "https://api.midjourney.com/v1/v6",
                    Priority = 1,
                    IsActive = true,
                    Version = "v6",
                    Capabilities = "image generation",
                    CostPerToken = 0.045M,
                    Regions = "global",
                    SuccessRate = 0.93M,
                    AvgLatencyMs = 200,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            await db.SaveChangesAsync();
        }
    }


    public static class Batch3SeederPartB
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            if (!db.AIModels.Any(m => m.Name == "DeepSeek-Math"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 24,
                    ProviderId = 12, // DeepSeek
                    Name = "DeepSeek-Math",
                    TaskType = "math",
                    ApiEndpoint = "https://api.deepseek.com/v1/math",
                    Priority = 1,
                    IsActive = true,
                    Version = "v1.0",
                    Capabilities = "math reasoning",
                    CostPerToken = 0.009M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.89M,
                    AvgLatencyMs = 145,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "DeepSeek-Chat"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 25,
                    ProviderId = 12, // DeepSeek
                    Name = "DeepSeek-Chat",
                    TaskType = "reasoning",
                    ApiEndpoint = "https://api.deepseek.com/v1/chat",
                    Priority = 2,
                    IsActive = true,
                    Version = "v1.0",
                    Capabilities = "text, reasoning, conversation",
                    CostPerToken = 0.011M,
                    Regions = "us-east, eu-west",
                    SuccessRate = 0.90M,
                    AvgLatencyMs = 150,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            await db.SaveChangesAsync();
        }
    }

    public static class Batch4Seeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // === Providers ===
            if (!db.Providers.Any(p => p.Name == "NVIDIA"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 16,
                    Name = "NVIDIA",
                    Vendor = "NVIDIA",
                    Website = "https://developer.nvidia.com/isaac-sim",
                    IsActive = true,
                    TrustLevel = TrustLevel.Enterprise,
                    ComplianceTags = ComplianceTag.SOC2 | ComplianceTag.ISO27001,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Siemens"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 17,
                    Name = "Siemens",
                    Vendor = "Siemens",
                    Website = "https://siemens.com/industrial-ai",
                    IsActive = true,
                    TrustLevel = TrustLevel.Enterprise,
                    ComplianceTags = ComplianceTag.ISO27001 | ComplianceTag.GDPR,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Atomwise"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 18,
                    Name = "Atomwise",
                    Vendor = "Atomwise",
                    Website = "https://atomwise.com",
                    IsActive = true,
                    TrustLevel = TrustLevel.Experimental,
                    ComplianceTags = ComplianceTag.ResearchUse,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.Providers.Any(p => p.Name == "Baker Lab"))
            {
                db.Providers.Add(new Provider
                {
                    Id = 19,
                    Name = "Baker Lab",
                    Vendor = "University of Washington",
                    Website = "https://rosettacommons.org",
                    IsActive = true,
                    TrustLevel = TrustLevel.Experimental,
                    ComplianceTags = ComplianceTag.ResearchUse,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            // === Models ===
            if (!db.AIModels.Any(m => m.Name == "Isaac Sim"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 29,
                    ProviderId = 16,
                    Name = "Isaac Sim",
                    TaskType = "robotics-simulation",
                    ApiEndpoint = "https://api.nvidia.com/v1/isaacsim",
                    Priority = 1,
                    IsActive = true,
                    Version = "2025",
                    Capabilities = "robotics simulation, reinforcement learning",
                    CostPerToken = 0.030M,
                    Regions = "us-west, eu-west",
                    SuccessRate = 0.95M,
                    AvgLatencyMs = 170,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "Industrial AI Platform"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 30,
                    ProviderId = 17,
                    Name = "Industrial AI Platform",
                    TaskType = "industrial-automation",
                    ApiEndpoint = "https://api.siemens.com/v1/industrialai",
                    Priority = 1,
                    IsActive = true,
                    Version = "2025",
                    Capabilities = "automation, predictive maintenance",
                    CostPerToken = 0.025M,
                    Regions = "eu-central, us-east",
                    SuccessRate = 0.94M,
                    AvgLatencyMs = 160,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "AtomNet"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 31,
                    ProviderId = 18,
                    Name = "AtomNet",
                    TaskType = "drug-discovery",
                    ApiEndpoint = "https://api.atomwise.com/v1/atomnet",
                    Priority = 1,
                    IsActive = true,
                    Version = "2025",
                    Capabilities = "drug screening, molecular analysis",
                    CostPerToken = 0.050M,
                    Regions = "us-east",
                    SuccessRate = 0.90M,
                    AvgLatencyMs = 200,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            if (!db.AIModels.Any(m => m.Name == "RoseTTAfold"))
            {
                db.AIModels.Add(new AIModel
                {
                    Id = 32,
                    ProviderId = 19,
                    Name = "RoseTTAfold",
                    TaskType = "protein-structure",
                    ApiEndpoint = "https://api.rosettacommons.org/v1/rosettafold",
                    Priority = 1,
                    IsActive = true,
                    Version = "2025",
                    Capabilities = "protein structure prediction",
                    CostPerToken = 0.045M,
                    Regions = "us-west",
                    SuccessRate = 0.89M,
                    AvgLatencyMs = 210,
                    HealthStatus = HealthStatus.Healthy,
                    CreatedAt = new DateTime(2025, 01, 01)
                });
            }

            await db.SaveChangesAsync();
        }
    }

    public static class Seed
    {
        public static async Task SeedAllAsync(ApplicationDbContext db)
        {
            //await db.Database.MigrateAsync();

            await DbSeeder_1.SeedAsync(db);
            await Batch3ASeeder.SeedAsync(db);
            await Batch3Seeder.SeedAsync(db);
            await Batch3SeederPartB.SeedAsync(db);
            await Batch4Seeder.SeedAsync(db);
            await db.SaveChangesAsync();
        }
    }
}



