using KiConsoleFramework.Models;
using KiConsoleFramework.Views;

namespace KiConsoleFramework
  {
  /// <summary>
  /// Performs such-and-such
  /// </summary>
  class Program
    {

    private static readonly Biz biz = new();
      // COMPOSITION ROOT; exposes elements of the MODEL

    private static ClassOneInteraction classOneInteraction;

    /// <summary>
    /// Serves as the CONTROLLER
    /// </summary>
    /// <param name="args">Command line arguments</param>
    static void Main(string[] args)
      {
      classOneInteraction = new ClassOneInteraction();
      classOneInteraction.OnQuitCommanded += biz.classOne.Quit;
        // An Interaction acts as a VIEW.  If any parameters are needed in addition to the command line args, the Interaction's
        // constructor prompts the user for, and returns, such parameters.  An Interaction used by the controller inside a loop
        // must also expose BeQuitCommanded.

      //--
      //
      // Wire up the view to observe the model and execute the business processing.
      //
      //--
      biz.classOne.OnProgress += classOneInteraction.ShowProgress;
      biz.classOne.OnCompletion += classOneInteraction.ShowCompletion;
      biz.classOne.OnDebug += classOneInteraction.ShowDebug;
      biz.classOne.OnWarning += classOneInteraction.ShowWarning;
      biz.classOne.OnError += classOneInteraction.ShowError;
      biz.classOne.OnFailure += classOneInteraction.ShowFailure;
      //
      biz.classOne.Process // Perform this class of processing.
        (
        parameterOne:classOneInteraction.ParameterOne,
        parameterTwo:classOneInteraction.ParameterTwo
        );
      }

    }
  }
