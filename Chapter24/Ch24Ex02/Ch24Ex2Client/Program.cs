using static System.Console;
using System.ServiceModel;
using Ch24Ex02Contracts;


namespace Ch24Ex2Client
{
  class Program
  {
    static void Main(string[] args)
    {
      Person[] people = new Person[]
      {
        new Person { Mark = 46, Name="Jim" },
        new Person { Mark = 73, Name="Mike" },
        new Person { Mark = 92, Name="Stefan" },
        new Person { Mark = 24, Name="Arthur" }
      };
      WriteLine("People:");
      OutputPeople(people);
      IAwardService client = ChannelFactory<IAwardService>.CreateChannel(
         new WSHttpBinding(),
         new EndpointAddress("http://localhost:59558/AwardService.svc"));
      client.SetPassMark(70);
      Person[] awardedPeople = client.GetAwardedPeople(people);
      WriteLine();
      WriteLine("Awarded people:");
      OutputPeople(awardedPeople);
      ReadKey();
    }
    static void OutputPeople(Person[] people)
    {
      foreach (Person person in people)
        WriteLine("{0}, mark: {1}", person.Name, person.Mark);
    }
  }
}
