using CubeMicroservice;

var builder = Host.CreateApplicationBuilder(args);

// Register the CubeWorker here!
builder.Services.AddHostedService<CubeWorker>();

var host = builder.Build();
host.Run();