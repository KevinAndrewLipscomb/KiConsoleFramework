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

    private static bool done = false;

    /// <summary>
    /// Serves as the CONTROLLER
    /// </summary>
    /// <param name="args">Command line arguments</param>
    static void Main(string[] args)
      {
      while (!done)
        {
        classOneInteraction = new ClassOneInteraction();
          // An Interaction acts as a VIEW.  If any parameters are needed in addition to the command line args, the Interaction's
          // constructor prompts the user for, and returns, such parameters.  An Interaction used by the controller inside a loop
          // must also expose BeQuitCommanded.

        if (classOneInteraction.BeQuitCommanded)
          {
          done = true;
          }
        else
          {
          biz.classOne.Process // Perform this class of processing.
            (
            parameterOne:classOneInteraction.ParameterOne,
            parameterTwo:classOneInteraction.ParameterTwo,
            OnProgress:classOneInteraction.ShowProgress,
            OnElaboration:classOneInteraction.ShowElaboration,
            OnWarning:classOneInteraction.ShowWarning,
            OnError:classOneInteraction.ShowError,
            OnFailure:ProcessFailure,
            OnCompletion:ProcessCompletion,
            OnDebug:classOneInteraction.ShowDebug
            );
          }
        }
      }

    static void ProcessFailure(ClassOneBiz.FailureInfo info)
      {
      classOneInteraction.ShowFailure(info);
      done = true;
      }

    static void ProcessCompletion(ClassOneBiz.CompletionInfo info)
      {
      classOneInteraction.ShowCompletion(info);
      done = true;
      }

    }
  }
