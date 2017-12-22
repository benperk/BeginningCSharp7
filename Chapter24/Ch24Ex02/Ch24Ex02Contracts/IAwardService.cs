using System.ServiceModel;

namespace Ch24Ex02Contracts
{
  [ServiceContract(SessionMode = SessionMode.Required)]
  public interface IAwardService
  {
    [OperationContract(IsOneWay = true, IsInitiating = true)]
    void SetPassMark(int passMark);
    [OperationContract]
    Person[] GetAwardedPeople(Person[] peopleToTest);
  }
}
