using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Core.Models
{
    public class ArbitrationContext
    {
        public string TaskType { get; set; } = string.Empty;
        public List<string> RequiredCapabilities { get; set; } = new(); // from payload metadata
        public decimal? MaxCostPerToken { get; set; }                   // request-level constraint
        public string? RequiredRegion { get; set; }                     // data residency
        public string Sensitivity { get; set; } = "standard";           // e.g., "high"
        public List<ArbitrationPolicy> Policies { get; set; } = new();  // ordered by scope priority
    }
}
