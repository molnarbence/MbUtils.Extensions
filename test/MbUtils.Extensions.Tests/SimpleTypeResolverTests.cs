using MbUtils.Extensions.SpectreConsole;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MbUtils.Extensions.Tests;

public sealed class SimpleTypeResolverTests
{
   [Fact]
   public void Resolve_NullType_ReturnsNull()
   {
      using var resolver = new SimpleTypeResolver(new ServiceCollection().BuildServiceProvider());

      Assert.Null(resolver.Resolve(null));
   }

   [Fact]
   public void Resolve_TypeRegisteredThroughRegistrar_ReturnsInstance()
   {
      var registrar = new SimpleTypeRegistrar(new ServiceCollection());
      registrar.Register(typeof(IDisposable), typeof(MemoryStream));

      using var resolver = (SimpleTypeResolver)registrar.Build();

      Assert.IsType<MemoryStream>(resolver.Resolve(typeof(IDisposable)));
   }
}
