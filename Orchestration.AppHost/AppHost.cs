var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Orchestration_API>("orchestration-api");

builder.Build().Run();
