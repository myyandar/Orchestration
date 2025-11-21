using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Core.Models
{
    public enum PolicyScope { Global, Tenant, Project, Scenario }

    public class ArbitrationPolicy
    {
        public string Name { get; set; } = string.Empty;
        public PolicyScope Scope { get; set; } = PolicyScope.Global;

        // Constraints (hard filters)
        public decimal? MaxCostPerToken { get; set; }
        public List<string> RequireCapabilities { get; set; } = new();
        public List<string> AllowedProviders { get; set; } = new();     // e.g., ["OpenAI","Microsoft"]
        public List<string> DeniedProviders { get; set; } = new();      // e.g., ["UnknownVendor"]
        public List<string> AllowedRegions { get; set; } = new();       // e.g., ["eu-west"]
        public bool RequireHealthyOnly { get; set; } = true;
        public List<string> RequireComplianceTags { get; set; } = new();// e.g., ["SOC2","ISO27001"]

        // Preferences (soft scoring)
        public bool PreferLowerCost { get; set; } = true;
        public bool PreferHigherSuccessRate { get; set; } = true;
        public bool PreferLowerLatency { get; set; } = false;
        public bool PreferEnterpriseTrust { get; set; } = true;

        // Overrides
        public string? PinModelName { get; set; }   // e.g., "GPT-5"
        public string? PinProviderName { get; set; } // e.g., "Microsoft"
    }
}
