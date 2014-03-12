using System.ServiceModel;

namespace MonoConcurrentWcfRequestsDemo
{
    [ServiceContract]
    public interface IFirstService
    {
        [OperationContract]
        void CallSecondService();
        [OperationContract]
        void CallSecondServiceInSeparateThread();
    }
}
