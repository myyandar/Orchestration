using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Data.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int RequestId { get; set; } // Foreign Key to RequestLog
        public string ArbitrationReasoning { get; set; }
        public List<string> ComplianceTags { get; set; }
        public DateTime Timestamp { get; set; }
        public string Region { get; set; }
        public string Endpoint { get; set; } // API endpoint URL
        public string HashSignature { get; set; } // future blockchain integration
    }
}
