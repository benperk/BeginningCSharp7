using Ch24Ex03;
using System.ServiceModel;
using static System.Console;

namespace Ch24Ex03Client
{
  class Program
  {
    static void Main(string[] args)
    {
      WriteLine("Press enter to begin.");
      ReadLine();
      WriteLine("Opening channel.");
      IAppControlService client =
         ChannelFactory<IAppControlService>.CreateChannel(
            new NetTcpBinding(),
            new EndpointAddress(
               "net.tcp://localhost:8081/AppControlService"));
      WriteLine("Creating sun.");
      client.SetRadius(100, "yellow", 3);
      WriteLine("Press enter to continue.");
      ReadLine();
      WriteLine("Growing sun to red giant.");
      client.SetRadius(200, "Red", 5);
      WriteLine("Press enter to continue.");
      ReadLine();
      WriteLine("Collapsing sun to neutron star.");
      client.SetRadius(50, "AliceBlue", 2);
      WriteLine("Finished. Press enter to exit.");
      ReadLine();
    }
  }
}
