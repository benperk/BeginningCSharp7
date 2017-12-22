using System;
using System.ServiceModel;

namespace Ch24Ex03
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class AppControlService : IAppControlService
  {
    private MainWindow hostApp;
    public AppControlService(MainWindow hostApp)
    {
      this.hostApp = hostApp;
    }
    public void SetRadius(int radius, string foreTo, int seconds)
    {
      hostApp.SetRadius(radius, foreTo, new TimeSpan(0, 0, seconds));
    }
  }

}
