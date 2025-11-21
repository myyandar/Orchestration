namespace Orchestration.API.Models
{
    public class OrchestrationRequest
    {
        public string TaskType { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty; // e.g. text to summarize, reasoning input, etc.
    }
}
