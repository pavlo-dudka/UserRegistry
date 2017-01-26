using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity.Wcf;

namespace UserRegistry.Core.WCF
{
    public class ServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.LoadConfiguration();
        }
    }
}