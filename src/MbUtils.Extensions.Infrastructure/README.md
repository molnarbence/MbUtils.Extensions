Infrastructure
==============
## ConfigurePOCO
Example usage when configuring services for dependency injection
```cs
IConfiguration config; // Application configuration (e.g. from a json file)

services.ConfigurePOCO<ClientConfig>(config.GetSection("ClientConfig"));
```
And then you can inject it
```cs
public class FooClient
{
    private readonly string baseUrl;     
    public FooClient(ClientConfig config)
    {
        baseUrl = config.BaseUrl;
    }
}
```
