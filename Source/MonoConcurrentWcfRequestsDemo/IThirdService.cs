using System.ServiceModel;

namespace MonoConcurrentWcfRequestsDemo
{
    [ServiceContract]
    public interface IThirdService
    {
        [OperationContract]
        void DoWork();
    }
}
