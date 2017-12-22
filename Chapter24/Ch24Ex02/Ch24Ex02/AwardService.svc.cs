using System.Collections.Generic;
using Ch24Ex02Contracts;
namespace Ch24Ex02
{
  public class AwardService : IAwardService
  {
    private int passMark;
    public void SetPassMark(int passMark)
    {
      this.passMark = passMark;
    }
    public Person[] GetAwardedPeople(Person[] peopleToTest)
    {
      List<Person> result = new List<Person>();
      foreach (Person person in peopleToTest)
      {
        if (person.Mark > passMark)
        {
          result.Add(person);
        }
      }
      return result.ToArray();
    }
  }
}

