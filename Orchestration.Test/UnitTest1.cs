using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orchestration.Core.Services;
using Xunit;
using Orchestration.Data; // Add this if ApplicationDbContext is in this namespace

namespace Orchestration.Test
{
    public class ArbitrationServiceTests
    {
        private readonly ArbitrationService _service;
        private readonly ApplicationDbContext _dbContext;

        public ArbitrationServiceTests()
        {
            // Create a mock or in-memory ApplicationDbContext for testing
            var dbContext = _dbContext; // Replace with appropriate constructor or mocking if needed
            _service = new ArbitrationService(dbContext);
        }

        [Theory]
        [InlineData("reasoning", "GPT-5")]
        [InlineData("summarization", "Claude")]
        [InlineData("other", "Gemini")]
        public async Task ChooseModelAsync_ReturnsPrimaryOrBackupOrNone(string taskType, string expectedPrimary)
        {
            var result = await _service.ChooseModelAsync(taskType);

            // Fix: Use Assert.Contains for string, not for IAsyncEnumerable<ArbitrationResult>
            Assert.Contains(result.ModelName, new[] { expectedPrimary, GetBackup(expectedPrimary), "No available model" });
        }

        private string GetBackup(string primary)
        {
            return primary switch
            {
                "GPT-5" => "Gemini",
                "Claude" => "HuggingFace",
                "Gemini" => "HuggingFace",
                _ => "HuggingFace"
            };
        }
    }
}