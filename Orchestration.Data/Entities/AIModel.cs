using Orchestration.Data.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Orchestration.Data.Entities
{
    public enum HealthStatus { Healthy, Degraded, Offline }
    public enum TrustLevel
    {
        Enterprise,   // Microsoft, OpenAI, Anthropic, Google DeepMind
        Standard,     // Cohere, AI21 Labs, Stability AI, Mistral, HuggingFace
        Experimental  // Research labs (Baker Lab, Atomwise), Midjourney, Black Forest Labs
    }

    public class AIModel
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public string ApiEndpoint { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public int Priority { get; set; } = 1;
        public bool IsActive { get; set; } = true;

        public string Version { get; set; } = string.Empty;
        public string Capabilities { get; set; } = string.Empty;
        public decimal CostPerToken { get; set; }

        public string Regions { get; set; } = string.Empty;
        public decimal? SuccessRate { get; set; }
        public int? AvgLatencyMs { get; set; }
        public HealthStatus HealthStatus { get; set; } = HealthStatus.Healthy;

        public DateTime CreatedAt { get; set; } = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        public DateTime? UpdatedAt { get; set; }
    }
}
