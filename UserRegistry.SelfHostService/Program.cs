using Microsoft.Practices.Unity;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using UserRegistry.Core;
using UserRegistry.Core.WCF;

namespace UserRegistry.SelfHostService
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            ICompaniesService companiesService = container.Resolve<ICompaniesService>();

            var baseAddress = "http://localhost:8080/wcf/CompaniesService.svc";
            using (var host = new ServiceHost(companiesService, new[] { new Uri(baseAddress) }))
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);

                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
