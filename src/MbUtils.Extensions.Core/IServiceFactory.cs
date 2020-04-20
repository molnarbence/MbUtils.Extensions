namespace MbUtils.Extensions
{
   public interface IServiceFactory<TService>
   {
      TService Get(string name);
   }
}
