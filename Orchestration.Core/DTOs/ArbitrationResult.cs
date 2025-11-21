using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Core.DTOs
{
    public class ArbitrationResult
    {
        public string ModelName { get; set; } = string.Empty;
        public string ProviderName { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public string ApiEndpoint { get; set; } = string.Empty;
        public string Capabilities { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public decimal CostPerToken { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
