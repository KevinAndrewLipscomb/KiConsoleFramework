using System;

namespace KiConsoleFramework.Orchestrator
  {
  public abstract partial class ObjectBiz
    {

    public class EventArgs
      {
      public string content = string.Empty;
      public EventArgs() {}
      public EventArgs(string content) { this.content = content; }
      }

    public class ReportSvc(ObjectBiz objectBiz)
      {
      public void ShowProgress(EventArgs e) => objectBiz.ReportProgress(e);
      public void ShowDebug(string text) => objectBiz.ReportDebug(text);
      public void ShowWarning(string text) => objectBiz.ReportWarning(text);
      public void ShowError(string text) => objectBiz.ReportError(text);
      //
      // Completion is excluded because it should be orchestrated (ie, only called by an ObjectBiz subclass).
      //
      }
    
    internal virtual void Quit(object sender = null, System.EventArgs e = null)
      {
      BeQuitCommanded = true;
      }

    internal event EventHandler<EventArgs> OnProgress, OnCompletion;
    internal event EventHandler<string> OnDebug, OnWarning, OnError, OnFailure;

    protected bool BeQuitCommanded = false;
    protected ReportSvc BaseReportService => InitializedReportSvc ??= new(this); // lazily loaded

    protected virtual void ReportProgress(EventArgs e) => OnProgress?.Invoke(this,e);
    protected virtual void ReportCompletion(EventArgs e) => OnCompletion?.Invoke(this,e);
    protected virtual void ReportDebug(string text) => OnDebug?.Invoke(this,text);
    protected virtual void ReportWarning(string text) => OnWarning?.Invoke(this,text);
    protected virtual void ReportError(string text) => OnError?.Invoke(this,text);
    protected virtual void ReportFailure(string text) => OnFailure?.Invoke(this,text);

    private ReportSvc InitializedReportSvc = null!;

    }
  }