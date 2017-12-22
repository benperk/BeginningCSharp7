using Ch24Ex01Client.ServiceReference1;
using static System.Console;

namespace Ch24Ex01Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Ch24Ex01Client";
            int intParam;
            do
            {
                WriteLine("Enter an integer and press enter to call the WCF service.");
            } while (!int.TryParse(ReadLine(), out intParam));
            Service1Client client = new Service1Client();
            WriteLine(client.GetData(intParam));
            WriteLine("Press an key to exit.");
            ReadKey();
        }
    }
}
