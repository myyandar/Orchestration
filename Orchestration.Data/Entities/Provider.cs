using Microsoft.EntityFrameworkCore;
using Orchestration.Data.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Orchestration.Data.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Vendor { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public TrustLevel TrustLevel { get; set; } = TrustLevel.Standard;
        public ComplianceTag ComplianceTags { get; set; } = ComplianceTag.None;

        public DateTime CreatedAt { get; set; } = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        public DateTime? UpdatedAt { get; set; }

        public ICollection<AIModel> AIModels { get; set; } = new List<AIModel>();
    }

    public enum ComplianceTag
    {
        None = 0,
        SOC2 = 1 << 0,
        ISO27001 = 1 << 1,
        HIPAA = 1 << 2,
        GDPR = 1 << 3,
        PCI_DSS = 1 << 4,
        FedRAMP = 1 << 5,
        ResearchUse = 1 << 6
    }


}

