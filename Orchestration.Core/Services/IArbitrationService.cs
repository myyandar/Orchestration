using Orchestration.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestration.Core.Services
{
    public interface IArbitrationService
    {
        Task<ArbitrationResult> ChooseModelAsync(string taskType);
        Task<ArbitrationResult?> ChooseModelCapabilityAwareAsync(string taskType, string requiredCapability);
        Task<ArbitrationResult?> ChooseModelUnifiedAsync(string taskType, string requiredCapability, decimal maxCostPerToken = decimal.MaxValue);
    }
}
