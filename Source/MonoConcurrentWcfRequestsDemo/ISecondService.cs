using System.ServiceModel;

namespace MonoConcurrentWcfRequestsDemo
{
    [ServiceContract]
    public interface ISecondService
    {
        [OperationContract]
        void DoWork();
    }
}
