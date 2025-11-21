using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Orchestration.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnhancedAIModelAndProviderEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrchestrationLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrchestrationLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrchestrationLogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "ComplianceTags",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrustLevel",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvgLatencyMs",
                table: "AIModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthStatus",
                table: "AIModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Regions",
                table: "AIModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "SuccessRate",
                table: "AIModels",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvgLatencyMs", "Capabilities", "CostPerToken", "HealthStatus", "Regions", "SuccessRate", "Version" },
                values: new object[] { 120, "text, reasoning, multimodal", 0.020m, 0, "us-east, eu-west", 0.98m, "v5.0" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvgLatencyMs", "Capabilities", "CostPerToken", "HealthStatus", "Name", "Regions", "SuccessRate", "Version" },
                values: new object[] { 150, "text, summarization, reasoning", 0.018m, 0, "Claude 4.1", "us-east, eu-west", 0.97m, "v4.1" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvgLatencyMs", "Capabilities", "CostPerToken", "HealthStatus", "Priority", "Regions", "SuccessRate", "Version" },
                values: new object[] { 140, "text, multimodal", 0.017m, 0, 1, "us-central, eu-west", 0.96m, "v1.5" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiEndpoint", "AvgLatencyMs", "Capabilities", "CostPerToken", "HealthStatus", "Name", "Priority", "ProviderId", "Regions", "SuccessRate", "TaskType", "Version" },
                values: new object[] { "https://api.microsoft.com/v1/copilot", 130, "text, reasoning, productivity", 0.019m, 0, "Copilot", 1, 11, "us-east, eu-west", 0.95m, "productivity", "2025" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiEndpoint", "AvgLatencyMs", "Capabilities", "CostPerToken", "HealthStatus", "Name", "Priority", "ProviderId", "Regions", "SuccessRate", "TaskType", "Version" },
                values: new object[] { "https://api.alibaba.com/v1/qwen3", 160, "multilingual text generation", 0.008m, 0, "Qwen 3", 1, 10, "asia-east, eu-west", 0.94m, "multilingual", "v3.0" });

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ComplianceTags", "TrustLevel", "Vendor" },
                values: new object[] { 11, 0, "OpenAI" });

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ComplianceTags", "TrustLevel", "Vendor" },
                values: new object[] { 11, 0, "Anthropic" });

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ComplianceTags", "TrustLevel", "Vendor" },
                values: new object[] { 11, 0, "Google" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "ComplianceTags", "CreatedAt", "IsActive", "Name", "TrustLevel", "UpdatedAt", "Vendor", "Website" },
                values: new object[,]
                {
                    { 10, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Alibaba DAMO Academy", 0, null, "Alibaba", "https://damo.alibaba.com" },
                    { 11, 15, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Microsoft Azure AI", 0, null, "Microsoft", "https://azure.microsoft.com/ai" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "ComplianceTags",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "TrustLevel",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "AvgLatencyMs",
                table: "AIModels");

            migrationBuilder.DropColumn(
                name: "HealthStatus",
                table: "AIModels");

            migrationBuilder.DropColumn(
                name: "Regions",
                table: "AIModels");

            migrationBuilder.DropColumn(
                name: "SuccessRate",
                table: "AIModels");

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capabilities", "CostPerToken", "Version" },
                values: new object[] { "", 0m, "" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Capabilities", "CostPerToken", "Name", "Version" },
                values: new object[] { "", 0m, "Claude 3", "" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Capabilities", "CostPerToken", "Priority", "Version" },
                values: new object[] { "", 0m, 2, "" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiEndpoint", "Capabilities", "CostPerToken", "Name", "Priority", "ProviderId", "TaskType", "Version" },
                values: new object[] { "https://api.huggingface.co/falcon", "", 0m, "Falcon", 3, 4, "reasoning", "" });

            migrationBuilder.UpdateData(
                table: "AIModels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiEndpoint", "Capabilities", "CostPerToken", "Name", "Priority", "ProviderId", "TaskType", "Version" },
                values: new object[] { "https://api.huggingface.co/bloom", "", 0m, "BLOOM", 3, 4, "summarization", "" });

            migrationBuilder.InsertData(
                table: "OrchestrationLogs",
                columns: new[] { "Id", "ChosenModel", "Payload", "ProviderResult", "TaskType", "Timestamp" },
                values: new object[,]
                {
                    { 1, "GPT-5", "Explain Newton's laws of motion", "[GPT-5] processed payload: Explain Newton's laws of motion", "reasoning", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "Claude", "Summarize the French Revolution", "[Claude] processed payload: Summarize the French Revolution", "summarization", new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Gemini", "Translate 'Hello' to Spanish", "[Gemini] processed payload: Translate 'Hello' to Spanish", "other", new DateTime(2025, 1, 3, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Vendor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Vendor",
                value: "");

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Vendor",
                value: "");

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt", "Vendor", "Website" },
                values: new object[] { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "HuggingFace", null, "", "https://huggingface.co" });
        }
    }
}
