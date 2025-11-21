using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Data.Entities
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string TimeStamp { get; set; }
        public string UserIdOrAPIKey { get; set; } // or API Key
        public int TaskType { get; set; } // (e.g., summarization, reasoning)
        public string ChosenModel { get; set; }
        public decimal CostEstimate { get; set; }
        public int Latency { get; set; }
        public bool FailoverFlag { get; set; }
    }
}

