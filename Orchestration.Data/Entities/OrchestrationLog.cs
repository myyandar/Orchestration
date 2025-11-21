using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Data.Entities
{
    public class OrchestrationLog
    {
        public int Id { get; set; }
        public string TaskType { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public string ChosenModel { get; set; } = string.Empty;
        public string ProviderResult { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
