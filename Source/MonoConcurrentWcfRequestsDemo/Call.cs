using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MonoConcurrentWcfRequestsDemo
{
    public static class Call<T> where T : class
    {
        public static void At(string url, Action<T> work)
        {
            ChannelFactory<T> factory = null;
            try
            {
                factory = new ChannelFactory<T>(new BasicHttpBinding());
                var service = factory.CreateChannel(new EndpointAddress(url));
                Debug.Assert(service != null, "service != null");
                work(service);
                factory.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
                if (factory != null)
                    factory.Abort();
                throw;
            }
        }
    }
}