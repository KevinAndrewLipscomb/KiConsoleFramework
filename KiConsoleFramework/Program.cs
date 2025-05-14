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
      }

    static internal void Work
      (
      string[] args
      )
      {
      //
      // Wire up the view to observe each public ObjectBiz field/class in the model.
      //
      foreach(var field_info in typeof(Biz).GetFields())
        {
        if (field_info.FieldType.IsSubclassOf(typeof(ObjectBiz)))
          {
          (field_info.GetValue(biz) as ObjectBiz).OnProgress += mainInteraction.ShowProgress;
          (field_info.GetValue(biz) as ObjectBiz).OnCompletion += mainInteraction.ShowCompletion;
          (field_info.GetValue(biz) as ObjectBiz).OnDebug += mainInteraction.ShowDebug;
          (field_info.GetValue(biz) as ObjectBiz).OnWarning += mainInteraction.ShowWarning;
          (field_info.GetValue(biz) as ObjectBiz).OnError += mainInteraction.ShowError;
          (field_info.GetValue(biz) as ObjectBiz).OnFailure += mainInteraction.ShowFailure;
          }
        }
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
