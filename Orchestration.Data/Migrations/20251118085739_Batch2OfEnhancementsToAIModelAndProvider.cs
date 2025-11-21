using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Orchestration.Data.Migrations
{
    /// <inheritdoc />
    public partial class Batch2OfEnhancementsToAIModelAndProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "ComplianceTags", "CreatedAt", "IsActive", "Name", "TrustLevel", "UpdatedAt", "Vendor", "Website" },
                values: new object[,]
                {
                    { 4, 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "HuggingFace", 1, null, "HuggingFace", "https://huggingface.co" },
                    { 5, 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Meta AI", 1, null, "Meta", "https://ai.meta.com" },
                    { 6, 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Mistral AI", 1, null, "Mistral", "https://mistral.ai" },
                    { 7, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Cohere", 1, null, "Cohere", "https://cohere.com" },
                    { 8, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "AI21 Labs", 1, null, "AI21 Labs", "https://ai21.com" }
                });

            migrationBuilder.InsertData(
                table: "AIModels",
                columns: new[] { "Id", "ApiEndpoint", "ApiKey", "AvgLatencyMs", "Capabilities", "CostPerToken", "CreatedAt", "HealthStatus", "IsActive", "Name", "Priority", "ProviderId", "Regions", "SuccessRate", "TaskType", "UpdatedAt", "Version" },
                values: new object[,]
                {
                    { 6, "https://api.meta.com/v1/llama3", "", 135, "text, reasoning", 0.006m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "LLaMA 3", 1, 5, "us-east, eu-west", 0.93m, "reasoning", null, "v3.0" },
                    { 7, "https://api.mistral.ai/v1/mistral7b", "", 125, "lightweight text generation", 0.003m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Mistral 7B", 1, 6, "eu-west", 0.91m, "reasoning", null, "7B" },
                    { 8, "https://api.mistral.ai/v1/mixtral", "", 145, "mixture of experts", 0.004m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Mixtral 8x7B", 2, 6, "eu-west", 0.90m, "reasoning", null, "8x7B" },
                    { 9, "https://api.huggingface.co/v1/bloom", "", 170, "multilingual text generation", 0.005m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "BLOOM", 1, 4, "global", 0.89m, "reasoning", null, "v1.0" },
                    { 10, "https://api.huggingface.co/v1/falcon", "", 165, "text generation", 0.004m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Falcon", 2, 4, "global", 0.88m, "reasoning", null, "v1.0" },
                    { 11, "https://api.cohere.ai/v1/command-r-plus", "", 155, "RAG, text generation", 0.015m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Command R+", 1, 7, "us-east, eu-west", 0.92m, "retrieval-augmented", null, "R+" },
                    { 12, "https://api.ai21.com/v1/jurassic2", "", 150, "text generation", 0.012m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Jurassic-2", 1, 8, "us-east, eu-west", 0.91m, "text-generation", null, "v2.0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "ComplianceTags", "CreatedAt", "IsActive", "Name", "TrustLevel", "UpdatedAt", "Vendor", "Website" },
                values: new object[,]
                {
                    { 1, 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "OpenAI", 0, null, "OpenAI", "https://openai.com" },
                    { 2, 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Anthropic", 0, null, "Anthropic", "https://anthropic.com" },
                    { 3, 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Google DeepMind", 0, null, "Google", "https://deepmind.google" },
                    { 10, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Alibaba DAMO Academy", 0, null, "Alibaba", "https://damo.alibaba.com" },
                    { 11, 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Microsoft Azure AI", 0, null, "Microsoft", "https://azure.microsoft.com/ai" }
                });

            migrationBuilder.InsertData(
                table: "AIModels",
                columns: new[] { "Id", "ApiEndpoint", "ApiKey", "AvgLatencyMs", "Capabilities", "CostPerToken", "CreatedAt", "HealthStatus", "IsActive", "Name", "Priority", "ProviderId", "Regions", "SuccessRate", "TaskType", "UpdatedAt", "Version" },
                values: new object[,]
                {
                    { 1, "https://api.openai.com/v1/gpt5", "", 120, "text, reasoning, multimodal", 0.020m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "GPT-5", 1, 1, "us-east, eu-west", 0.98m, "reasoning", null, "v5.0" },
                    { 2, "https://api.anthropic.com/v1/claude", "", 150, "text, summarization, reasoning", 0.018m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Claude 4.1", 1, 2, "us-east, eu-west", 0.97m, "summarization", null, "v4.1" },
                    { 3, "https://api.google.com/v1/gemini", "", 140, "text, multimodal", 0.017m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Gemini 1.5", 1, 3, "us-central, eu-west", 0.96m, "reasoning", null, "v1.5" },
                    { 4, "https://api.microsoft.com/v1/copilot", "", 130, "text, reasoning, productivity", 0.019m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Copilot", 1, 11, "us-east, eu-west", 0.95m, "productivity", null, "2025" },
                    { 5, "https://api.alibaba.com/v1/qwen3", "", 160, "multilingual text generation", 0.008m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0, true, "Qwen 3", 1, 10, "asia-east, eu-west", 0.94m, "multilingual", null, "v3.0" }
                });
        }
    }
}
