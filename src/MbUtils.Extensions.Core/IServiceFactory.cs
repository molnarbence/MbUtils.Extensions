namespace MbUtils.Extensions.Core
{
    public interface IServiceFactory<TService>
    {
         TService Get(string name);
    }
}