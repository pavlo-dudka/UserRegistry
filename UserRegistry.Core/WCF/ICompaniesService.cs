using System.ServiceModel;

namespace UserRegistry.Core.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompaniesService" in both code and config file together.
    [ServiceContract]
    public interface ICompaniesService
    {
        [OperationContract]
        int GetUsersCount(int id);
    }
}
