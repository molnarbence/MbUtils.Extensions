// See https://aka.ms/new-console-template for more information

using MbUtils.Extensions.SpectreConsole;
using Microsoft.Extensions.DependencyInjection;
using TestSpectreConsoleApp;

var host = new SpectreConsoleHost();

host.Services.AddSingleton<IBarService, BarService>();

host.Configure(config => config.AddCommand<FooCommand>("foo"));

return await host.RunAsync(args);
