using System;
using System.ServiceModel;

namespace MonoConcurrentWcfRequestsDemo
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ThirdService : IThirdService
    {
        public void DoWork()
        {
            Console.WriteLine("ThirdService.DoWork");
        }
    }
}
