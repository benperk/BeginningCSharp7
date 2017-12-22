using System.ServiceModel;

namespace Ch24Ex03
{
  [ServiceContract]
  public interface IAppControlService
  {
    [OperationContract]
    void SetRadius(int radius, string foreTo, int seconds);
  }
}
