using System;
using System.Collections.Generic;
using System.ServiceModel;
using MonoConcurrentWcfRequestsDemo.Properties;

namespace MonoConcurrentWcfRequestsDemo
{
    class Program
    {
        private static List<ServiceHost> serviceHosts = new List<ServiceHost>(3);

        static void Main(string[] args)
        {
            string firstServiceUrl = Settings.Default.FirstServiceUrl;
            
            Console.WriteLine("Host services...");
            Host<FirstService>(firstServiceUrl);
            Host<SecondService>(Settings.Default.SecondServiceUrl);
            Host<ThirdService>(Settings.Default.ThirdServiceUrl);
            
            Console.WriteLine();
            Console.WriteLine(" - Do concurrent call in a background thread");
            Call<IFirstService>.At(firstServiceUrl, x => x.CallSecondServiceInSeparateThread());
            Console.WriteLine(" - Done");

            Console.WriteLine();
            Console.WriteLine(" - Do concurrent call right from WCF Service method");
            Call<IFirstService>.At(firstServiceUrl, x => x.CallSecondService());
            Console.WriteLine(" - Done");
            
            Console.WriteLine("Closing services...");
            serviceHosts.ForEach(x => x.Close());
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void Host<TService>(string name) where TService : new()
        {
            var service = new TService();
            var serviceHost = new ServiceHost(service, new Uri(name));
            serviceHost.Open();
            serviceHosts.Add(serviceHost);
            
        }
    }
}
