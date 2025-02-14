using KiConsoleFramework.Repo.Interface;
using System;
using System.Collections.Specialized;
using System.Threading;

namespace KiConsoleFramework.Logic
  {
  public class ClassOneBiz : ObjectBiz
    {

    public ClassOneBiz // CONSTRUCTOR
      (
      NameValueCollection appSettings_imp,
      IClassOneRepo repo_imp
      )
      {
      Repo = repo_imp;
      AppSettings = appSettings_imp;
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
      try
        {
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
      catch (Exception e)
        {
        ReportFailure($"{e}");
        }
      }

    internal void Cancel()
      {
      Quit();
      }

    private readonly NameValueCollection AppSettings = null;
    private readonly IClassOneRepo Repo = null;

    }
  }
