WebSockets package
==================

## Configuring handler
Let's create a derived class
```cs
using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using MbUtils.Extensions.WebSockets;

namespace MbUtils.UrlPreheater.WebApp
{
    public class MainWebSocketHandler : WebSocketHandler
    {
        public MainWebSocketHandler(WebSocketConnectionManager connManager) : base(connManager)
        {            
        }

        public override Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessageAsync(string message)
        {
            await base.SendMessageToAllAsync(message);
        }
    }
}
```
And configure in the pipeline, "/ws/main" will be the endpoint for this service (ASP.NET Core project)
```cs
public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
{
    app.UseWebSockets();
    app.MapWebSocketManager("/ws/main", serviceProvider.GetService<MainWebSocketHandler>());
}
```
Then let's configure service
```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddWebSocketManager();
}
```
Now we can use the handler as an injectable (e.g. in a controller)
```cs
[Route("api/[controller]")]
public class FooController : Controller
{
    private readonly MainWebSocketHandler handler;
    public FooController(MainWebSocketHandler handler)
    {
        this.handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> SendMessageAsync(string message)
    {
        await this.handler.SendMessageAsync(viewModel);
        return Ok();
    }
}
```