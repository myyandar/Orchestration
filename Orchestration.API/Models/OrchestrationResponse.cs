namespace Orchestration.API.Models
{
    public class OrchestrationResponse
    {
        public string TaskType { get; set; } = string.Empty;
        public string ChosenModel { get; set; } = string.Empty;
        public string ProviderResult { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
