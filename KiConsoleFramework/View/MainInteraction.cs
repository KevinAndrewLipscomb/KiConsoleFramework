using KiConsoleFramework.Logic;
using kix;
using log4net;
using log4net.Config;
using Spectre.Console;
using System;
using System.Collections.Generic;

namespace KiConsoleFramework.View
  {
  class MainInteraction
    {
    // If any parameters are needed in addition to the command line args, provide a Get() method that prompts the user
    // for, and returns, such parameters.  If used by the controller inside a loop, expose BeQuitRequested.

    public string ParameterOne {get => parameterOne;}
    public string ParameterTwo {get => parameterTwo;}

    public event EventHandler OnQuitCommanded;
    protected virtual void ReportQuitCommanded() => OnQuitCommanded?.Invoke(this,null);

    public MainInteraction() // CONSTRUCTOR
      {
      XmlConfigurator.Configure(); // reads log4net configuration
      //
      parameterOne = AnsiConsole.Ask<string>(prompt:"Please enter a value for parameterOne:");
      parameterTwo = AnsiConsole.Ask<string>(prompt: "Please enter a value for parameterTwo:");
      //
      var message = "To quit, press any of ";
      foreach (var quitKey in quitKeyList)
        {
        message += $"{quitKey}{k.SPACE}|{k.SPACE}";
        }
      AnsiConsole.WriteLine(message.TrimEnd(new char[] {'|',k.SPACE[0]}));
      //
      if (BeQuitKeyPressed()) ReportQuitCommanded();
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
      AnsiConsole.WriteLine($"entityOne = {entityOne}");
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowProgress
      (
      object source,
      ClassOneBiz.EventArgs e)
      {
      if (BeUsingProgressWriteLines)
        {
        AnsiConsole.WriteLine($"{e.content}");
        }
      else
        {
        AnsiConsole.Write($"{e.content}");
        }
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowCompletion
      (
      object source,
      ClassOneBiz.EventArgs e
      )
      {
      AnsiConsole.WriteLine($"{e.content}");
      AnsiConsole.WriteLine("Program done.");
      }

    public void ShowFailure
      (
      object source,
      string text
      )
      {
      if (!BeUsingProgressWriteLines) AnsiConsole.WriteLine();
      log.Fatal($"{source}: {text}");
      log.Fatal("Program done.");
      Pause();
      }

    public void ShowDebug(object source, string text) => ShowExtraNormal(log.Debug, source, text);
    public void ShowWarning(object source, string text) => ShowExtraNormal(log.Warn, source, text);
    public void ShowError(object source, string text) => ShowExtraNormal(log.Error, source, text);

    public void Pause()
      {
      Console.Write("Press any key to continue . . . ");
      Console.ReadLine();
      }

    private static readonly ILog log = LogManager.GetLogger(typeof(MainInteraction));
    private bool BeUsingProgressWriteLines = false;
    private string parameterOne;
    private string parameterTwo;
    private readonly List<ConsoleKey> quitKeyList = new()
      {
      ConsoleKey.Enter,
      ConsoleKey.Escape,
      ConsoleKey.Q,
      ConsoleKey.Spacebar
      };

    private bool BeQuitKeyPressed()
      {
      return !Console.IsInputRedirected && Console.KeyAvailable && quitKeyList.Contains(Console.ReadKey(intercept:true).Key);
      }

    private void ShowExtraNormal
      (
      Action<object> logAction,
      object source,
      string text
      )
      {
      if(
          !BeUsingProgressWriteLines
        &&
          (
            (logAction == log.Debug && log.IsDebugEnabled)
          ||
            (logAction == log.Warn && log.IsWarnEnabled)
          ||
            (logAction == log.Error && log.IsErrorEnabled)
          )
        )
        {
        AnsiConsole.WriteLine();
        }
      logAction($"{source}: {text}");
      if (BeQuitKeyPressed())
        {
        ReportQuitCommanded();
        }
      }

    }
  }
