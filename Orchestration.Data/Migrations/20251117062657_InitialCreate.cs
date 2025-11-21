using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Orchestration.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ArbitrationReasoning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplianceTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashSignature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrchestrationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChosenModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrchestrationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIdOrAPIKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskType = table.Column<int>(type: "int", nullable: false),
                    ChosenModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostEstimate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Latency = table.Column<int>(type: "int", nullable: false),
                    FailoverFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AIModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capabilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerToken = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIModels_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrchestrationLogs",
                columns: new[] { "Id", "ChosenModel", "Payload", "ProviderResult", "TaskType", "Timestamp" },
                values: new object[,]
                {
                    { 1, "GPT-5", "Explain Newton's laws of motion", "[GPT-5] processed payload: Explain Newton's laws of motion", "reasoning", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "Claude", "Summarize the French Revolution", "[Claude] processed payload: Summarize the French Revolution", "summarization", new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Gemini", "Translate 'Hello' to Spanish", "[Gemini] processed payload: Translate 'Hello' to Spanish", "other", new DateTime(2025, 1, 3, 12, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt", "Vendor", "Website" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "OpenAI", null, "", "https://openai.com" },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Anthropic", null, "", "https://anthropic.com" },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Google DeepMind", null, "", "https://deepmind.google" },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "HuggingFace", null, "", "https://huggingface.co" }
                });

            migrationBuilder.InsertData(
                table: "AIModels",
                columns: new[] { "Id", "ApiEndpoint", "ApiKey", "Capabilities", "CostPerToken", "CreatedAt", "IsActive", "Name", "Priority", "ProviderId", "TaskType", "UpdatedAt", "Version" },
                values: new object[,]
                {
                    { 1, "https://api.openai.com/v1/gpt5", "", "", 0m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "GPT-5", 1, 1, "reasoning", null, "" },
                    { 2, "https://api.anthropic.com/v1/claude", "", "", 0m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Claude 3", 1, 2, "summarization", null, "" },
                    { 3, "https://api.google.com/v1/gemini", "", "", 0m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Gemini 1.5", 2, 3, "reasoning", null, "" },
                    { 4, "https://api.huggingface.co/falcon", "", "", 0m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "Falcon", 3, 4, "reasoning", null, "" },
                    { 5, "https://api.huggingface.co/bloom", "", "", 0m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, "BLOOM", 3, 4, "summarization", null, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AIModels_ProviderId",
                table: "AIModels",
                column: "ProviderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AIModels");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "OrchestrationLogs");

            migrationBuilder.DropTable(
                name: "RequestLogs");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
