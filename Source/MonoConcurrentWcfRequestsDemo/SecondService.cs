using System;
using System.ServiceModel;
using MonoConcurrentWcfRequestsDemo.Properties;

namespace MonoConcurrentWcfRequestsDemo
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SecondService : ISecondService
    {
        private string serviceUrl = Settings.Default.ThirdServiceUrl;
        public void DoWork()
        {
            Console.WriteLine("SecondService.DoWork");
            Call<IThirdService>.At(serviceUrl, x => x.DoWork());
            Console.WriteLine("SecondService.DoWork - Done");
        }
    }
}
