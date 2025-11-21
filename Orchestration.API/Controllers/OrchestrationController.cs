using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orchestration.API.Models;
using Orchestration.Core.Services;
using Orchestration.Data;
using Orchestration.Data.Entities;

namespace Orchestration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrchestrationController : ControllerBase
    {
        private readonly IArbitrationService _arbitrationService;
        private readonly ILogger<OrchestrationController> _logger;
        private readonly ApplicationDbContext _db; // EF Core DbContext for logging

        public OrchestrationController(
            IArbitrationService arbitrationService,
            ILogger<OrchestrationController> logger,
            ApplicationDbContext db)
        {
            _arbitrationService = arbitrationService;
            _logger = logger;
            _db = db;
        }

        [HttpPost("orchestrate")]
        public async Task<IActionResult> Orchestrate([FromBody] OrchestrationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.TaskType))
                return BadRequest("TaskType is required.");

            // 1. Call arbitration service
            var arbitrationResult = await _arbitrationService.ChooseModelAsync(request.TaskType);

            // 2. Send request to provider API (stub/mock for now)
            var providerResult = await SimulateProviderCall(arbitrationResult.ModelName, request.Payload);

            // 3. Log request + arbitration decision into SQL Server
            var logEntry = new OrchestrationLog
            {
                TaskType = request.TaskType,
                Payload = request.Payload,
                ChosenModel = arbitrationResult.ModelName,
                ProviderResult = providerResult,
                Timestamp = DateTime.UtcNow
            };

            _db.OrchestrationLogs.Add(logEntry);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Orchestration completed: {TaskType} -> {Model}", request.TaskType, arbitrationResult.ModelName);

            // 4. Return structured JSON response
            var response = new OrchestrationResponse
            {
                TaskType = request.TaskType,
                ChosenModel = arbitrationResult.ModelName,
                ProviderResult = providerResult,
                Timestamp = DateTime.UtcNow
            };

            return Ok(response);
        }

        // Stubbed provider call
        private async Task<string> SimulateProviderCall(string model, string payload)
        {
            await Task.Delay(200); // simulate latency
            return $"[{model}] processed payload: {payload}";
        }
    }
}
