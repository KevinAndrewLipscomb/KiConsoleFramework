using System.Threading;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace KiConsoleFramework
  {
  partial class Program
    {

    public const string ServiceName = "KiConsoleFrameworkService";

    public class Service : ServiceBase
      {

      public Service() // CONSTRUCTOR
        {
        ServiceName = Program.ServiceName;
        CancellationTokenSource = new();
        CancellationToken = CancellationTokenSource.Token;
        }

      protected override void OnStart(string[] args)
        {
        Task.Run
          (
          action:() => Program.Work
            (
            args:args,
            cancellationToken:CancellationToken
            ),
          cancellationToken:CancellationToken
          );
        }

      protected override void OnStop()
        {
        CancellationTokenSource.Cancel();
        CancellationTokenSource.Dispose();
        Stop();
        }

      private CancellationToken CancellationToken;
      private CancellationTokenSource CancellationTokenSource;

      }

    }
  }
