using System.ServiceModel;
using UserRegistry.Core.Repositories;

namespace UserRegistry.Core.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompanyRepository CompanyRepository;

        public CompaniesService()
        {

        }

        public CompaniesService(ICompanyRepository companyRepository)
        {
            CompanyRepository = companyRepository;
        }

        public int GetUsersCount(int id)
        {
            return CompanyRepository.GetUsersCount(id);
        }
    }
}
