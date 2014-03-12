using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using MonoConcurrentWcfRequestsDemo.Properties;

namespace MonoConcurrentWcfRequestsDemo
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class FirstService : IFirstService
    {
        private string secondServiceUrl = Settings.Default.SecondServiceUrl;

        public void CallSecondService()
        {
            Console.WriteLine("FirstService.CallSecondService");
            Call<ISecondService>.At(secondServiceUrl, x => x.DoWork());
            Console.WriteLine("FirstService.CallSecondService - Done");
        }

        public void CallSecondServiceInSeparateThread()
        {
            Console.WriteLine("FirstService.CallSecondServiceInSeparateThread");
            ThreadPool.QueueUserWorkItem(s => Call<ISecondService>.At(secondServiceUrl, x => x.DoWork()));
            Console.WriteLine("FirstService.CallSecondServiceInSeparateThread - Done");
        }
    }
}
