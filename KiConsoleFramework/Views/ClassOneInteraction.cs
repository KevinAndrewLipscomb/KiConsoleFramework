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
    private static readonly ILog log = LogManager.GetLogger(nameof(ClassOneInteraction));
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
      Console.Write("Please enter a value for parameterOne: ");
      parameterOne = Console.ReadLine();
      Console.Write("Please enter a value for parameterTwo: ");
      parameterTwo = Console.ReadLine();
      //
      var message = "To quit, press any of ";
      foreach (var quitKey in quitKeyList)
        {
        message += $"{quitKey}|";
        }
      Console.WriteLine($"{message.TrimEnd('|')}.");
      //
      beQuitCommanded = Console.KeyAvailable;
      }

    private bool BeQuitKeyPressed()
      {
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
      Console.WriteLine($"{info.content}");
      Console.WriteLine("Program done.");
      }

    public void ShowDebug(ClassOneBiz.DebugInfo info)
      {
      log.Debug($"{info.content}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowElaboration(ClassOneBiz.ElaborationInfo info)
      {
      log.Info($"{info.content}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowError(ClassOneBiz.ErrorInfo info)
      {
      log.Error($"{info.content}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowFailure(ClassOneBiz.FailureInfo info)
      {
      log.Fatal($"{info.content}");
      log.Fatal("Program done.");
      }

    public void ShowProgress(ClassOneBiz.ProgressInfo info)
      {
      //Console.Write($"{info.content}");
      Console.WriteLine($"{info.content}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    public void ShowWarning(ClassOneBiz.WarningInfo info)
      {
      log.Warn($"{info.content}");
      beQuitCommanded = BeQuitKeyPressed();
      }

    }
  }
