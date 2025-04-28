using MbUtils.Extensions.Tools;
using TestWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.AddConfig<FooConfig>(FooConfig.SectionName);

var host = builder.Build();
host.Run();
