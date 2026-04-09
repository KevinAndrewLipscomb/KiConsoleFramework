using KiConsoleFramework.Orchestrator;
using KiConsoleFramework.View;
using System;
using System.Diagnostics;

namespace KiConsoleFramework
  {
  /// <summary>
  /// Performs such-and-such.  Can be invoked as a console application or as a Windows Service.
  /// </summary>
  partial class Program
    {

    static readonly private Biz biz = new();
      // COMPOSITION ROOT; exposes elements of the MODEL

    static private MainInteraction mainInteraction;

    /// <summary>
    /// Serves as the CONTROLLER
    /// </summary>
    /// <param name="args">Command line arguments</param>
    static void Main(string[] args)
      {

      mainInteraction = new MainInteraction();
        // An Interaction acts as a VIEW.

      biz.ObjectBizLoaded += WireObjectBizDescendantToView(); // Observe for lazy-loading of ObjectBiz descendants so we can wire them up to the view.

      try
        {
        if (Environment.UserInteractive) // running as console app
          {
          mainInteraction.OnQuitCommanded += biz.classOne.Quit;
            // An Interaction used by the controller inside a loop must also expose BeQuitCommanded.  If any parameters are needed in
            // addition to the command line args, the Interaction's constructor prompts the user for, and returns, such parameters.
          }

        Work(args);
          // This blocks until the biz layer (the model) is complete.  The model observes the interaction (the view), which offers
          // the user a way to command a quit, so the model may complete on its own or quit at the behest of the user.

        }
      catch (Exception e)
        {
        mainInteraction.ShowFailure(Process.GetCurrentProcess().ProcessName,$"{e}");
        }

      static Action<ObjectBiz> WireObjectBizDescendantToView() => objectBiz =>
        {
        objectBiz.OnProgress += mainInteraction.ShowProgress;
        objectBiz.OnCompletion += mainInteraction.ShowCompletion;
        objectBiz.OnDebug += mainInteraction.ShowDebug;
        objectBiz.OnWarning += mainInteraction.ShowWarning;
        objectBiz.OnError += mainInteraction.ShowError;
        objectBiz.OnFailure += mainInteraction.ShowFailure;
        };

      static void Work
        (
        string[] args
        )
        {
        //
        // Execute the business processing.
        //
        biz.classOne.Process
          (
          parameterOne:mainInteraction.ParameterOne,
          parameterTwo:mainInteraction.ParameterTwo
          );
        }

      }

    }
  }
