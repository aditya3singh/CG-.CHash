using SquareMicroservice;

var builder = Host.CreateApplicationBuilder(args);

// Register the SquareWorker here!
builder.Services.AddHostedService<SquareWorker>();

var host = builder.Build();
host.Run();