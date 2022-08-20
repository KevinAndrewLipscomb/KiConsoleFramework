using KiConsoleFramework.Data;
using System;
using System.Threading;

namespace KiConsoleFramework.Models
  {
  public class ClassOneBiz
    {

    private readonly IClassOneDb classOneDb = null;
    private bool BeQuitCommanded = false;

    public class EventArgs
      {
      public string content = string.Empty;
      public EventArgs() {}
      public EventArgs(string content) { this.content = content; }
      }

    public event EventHandler<EventArgs> OnProgress, OnCompletion;
    public event EventHandler<string> OnDebug, OnWarning, OnError, OnFailure;

    protected virtual void ReportProgress(EventArgs e) => OnProgress?.Invoke(this,e);
    protected virtual void ReportCompletion(EventArgs e) => OnCompletion?.Invoke(this,e);
    protected virtual void ReportDebug(string text) => OnDebug?.Invoke(this,text);
    protected virtual void ReportWarning(string text) => OnWarning?.Invoke(this,text);
    protected virtual void ReportError(string text) => OnError?.Invoke(this,text);
    protected virtual void ReportFailure(string text) => OnFailure?.Invoke(this,text);

    public ClassOneBiz(IClassOneDb classOneDb_imp) // CONSTRUCTOR
      {
      classOneDb = classOneDb_imp;
      }

    public void Process
      (
      string parameterOne,
      string parameterTwo
      )
      {
      // --
      //
      // Perform this class of processing, monitoring for a commanded quit, and making reports as necessary.
      //
      // --
      var done = false;
      while (!BeQuitCommanded && !done)
        {
        ReportProgress(e:new("."));
        Thread.Sleep(millisecondsTimeout:1000);
        }
      //
      if (BeQuitCommanded)
        {
        ReportWarning(text:"Process interrupted.");
        }
      else
        {
        ReportCompletion(e:new("Process complete."));
        }
      }

    public void Quit(object sender, System.EventArgs e)
      {
      BeQuitCommanded = true;
      }

    }
  }
