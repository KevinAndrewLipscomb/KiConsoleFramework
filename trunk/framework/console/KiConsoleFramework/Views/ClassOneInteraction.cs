using KiConsoleFramework.Models;
using log4net;
using System;
using System.Collections.Generic;

namespace KiConsoleFramework.Views
  {
  class ClassOneInteraction
    {
    // If any parameters are needed in addition to the command line args, provide a Get() method that prompts the user
    // for, and returns, such parameters.  If used by the controller inside a loop, expose BeQuitRequested.

    private bool beQuitCommanded = false;
    private static readonly ILog log;
    private string parameterOne;
    private string parameterTwo;
    private readonly List<ConsoleKey> quitKeyList = new()
      {
      ConsoleKey.Enter,
      ConsoleKey.Escape,
      ConsoleKey.Q,
      ConsoleKey.Spacebar
      };

    public bool BeQuitCommanded {get => beQuitCommanded;}
    public string ParameterOne {get => parameterOne;}
    public string ParameterTwo {get => parameterTwo;}

    public ClassOneInteraction() // CONSTRUCTOR
      {
      beQuitCommanded = Console.KeyAvailable;
      }

    private bool BeQuitKeyPressed()
      {
      var message = "To quit, press any of ";
      foreach (var quitKey in quitKeyList)
        {
        message += $"{quitKey},";
        }
      Console.WriteLine($"{message.TrimEnd(',')}.");
      return Console.KeyAvailable && quitKeyList.Contains(Console.ReadKey(intercept:true).Key);
      }

    public void ShowEntityOne
      (
      string entityOne // trivial
      //
      // or complex
      //
      //string entityOne.AttributeFirst,
      //string entityOne.AttributeSecond
      )
      {
      Console.WriteLine($"entityOne = {entityOne}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowCompletion(ClassOneBiz.CompletionInfo info)
      {
      Console.WriteLine($"COMPLETION info = {info}");
      Console.WriteLine("Program done.");
      }

    public void ShowDebug(ClassOneBiz.DebugInfo info)
      {
      log.Debug($"{info}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowElaboration(ClassOneBiz.ElaborationInfo info)
      {
      log.Info($"{info}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowError(ClassOneBiz.ErrorInfo info)
      {
      log.Error($"{info}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowFailure(ClassOneBiz.FailureInfo info)
      {
      log.Fatal($"{info}");
      log.Fatal("Program done.");
      }

    public void ShowProgress(ClassOneBiz.ProgressInfo info)
      {
      //Console.Write($"{info}");
      Console.WriteLine($"{info}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowWarning(ClassOneBiz.WarningInfo info)
      {
      log.Warn($"{info}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    }
  }
