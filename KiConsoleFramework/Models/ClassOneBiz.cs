using KiConsoleFramework.Data;
using System;

namespace KiConsoleFramework.Models
  {
  public class ClassOneBiz
    {

    private readonly IClassOneDb classOneDb = null;

    private Action<CompletionInfo> ReportCompletion;
    private Action<DebugInfo> ReportDebug;
    private Action<ElaborationInfo> ReportElaboration;
    private Action<ErrorInfo> ReportError;
    private Action<FailureInfo> ReportFailure;
    private Action<ProgressInfo> ReportProgress;
    private Action<WarningInfo> ReportWarning;

    public class CompletionInfo
      {
      public string content = "";
      public CompletionInfo() {}
      public CompletionInfo(string content) { this.content = content; }
      }

    public class DebugInfo
      {
      public string content = "";
      public DebugInfo() {}
      public DebugInfo(string content) { this.content = content; }
      }

    public class ElaborationInfo
      {
      public string content = "";
      public ElaborationInfo() {}
      public ElaborationInfo(string content) { this.content = content; }
      }

    public class ErrorInfo
      {
      public string content = "";
      public ErrorInfo() {}
      public ErrorInfo(string content) { this.content = content; }
      }

    public class FailureInfo
      {
      public string content = "";
      public FailureInfo() {}
      public FailureInfo(string content) { this.content = content; }
      }

    public class ProgressInfo
      {
      public string content = "";
      public ProgressInfo() {}
      public ProgressInfo(string content) { this.content = content; }
      }

    public class WarningInfo
      {
      public string content = "";
      public WarningInfo() {}
      public WarningInfo(string content) { this.content = content; }
      }

    public ClassOneBiz(IClassOneDb classOneDb_imp) // CONSTRUCTOR
      {
      classOneDb = classOneDb_imp;
      }

    public void Process
      (
      string parameterOne,
      string parameterTwo,
      Action<ProgressInfo> OnProgress,
      Action<ElaborationInfo> OnElaboration,
      Action<WarningInfo> OnWarning,
      Action<ErrorInfo> OnError,
      Action<FailureInfo> OnFailure,
      Action<CompletionInfo> OnCompletion,
      Action<DebugInfo> OnDebug
      )
      {
      ReportProgress = OnProgress;
      ReportElaboration = OnElaboration;
      ReportWarning = OnWarning;
      ReportError = OnError;
      ReportFailure = OnFailure;
      ReportCompletion = OnCompletion;
      ReportDebug = OnDebug;
      // --
      //
      // Perform this class of processing, making reports as necessary.
      //
      // --
      ReportCompletion(new("Process complete."));
      }

    }
  }
