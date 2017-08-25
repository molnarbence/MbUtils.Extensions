Core package
============
## ServiceFactory
Example usage at configuring services for dependency injeciton
```cs
services
    .AddSingleton<SqlUserRepository>()
    .AddSingleton<CachedUserRepository>()
    .AddSingleton<IServiceFactory<IUserRepository>>(p => new ServiceFactory<IUserRepository> // resolves services by name
                {
                    { "default", () => p.GetService<SqlUserRepository>() },
                    { "cached", () => p.GetService<CachedUserRepository>() }
                })
```

## String extensions
```cs
var myString = "foo";
if(myString.IsNullOrEmpty()) // easy to use the extension method
{
    // foo
}

if(myString.HasValue()) // another extension method, for quick usage
{
    // bar
}
```
