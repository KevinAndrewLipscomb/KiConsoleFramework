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

    public string ParameterOne {get => parameterOne;}
    public string ParameterTwo {get => parameterTwo;}

    public event EventHandler OnQuitCommanded;
    protected virtual void ReportQuitCommanded() => OnQuitCommanded?.Invoke(this,null);

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
      if (BeQuitKeyPressed()) ReportQuitCommanded();
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
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowProgress
      (
      object source,
      ClassOneBiz.EventArgs e)
      {
      Console.Write($"{e.content}");
      //Console.WriteLine($"{e.content}");
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowCompletion
      (
      object source,
      ClassOneBiz.EventArgs e
      )
      {
      Console.WriteLine($"{e.content}");
      Console.WriteLine("Program done.");
      }

    public void ShowDebug
      (
      object source,
      string text
      )
      {
      log.Debug($"{source}: {text}");
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowWarning
      (
      object source,
      string text
      )
      {
      log.Warn($"{source}: {text}");
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowError
      (
      object source,
      string text
      )
      {
      log.Error($"{source}: {text}");
      if (BeQuitKeyPressed()) ReportQuitCommanded();
      }

    public void ShowFailure
      (
      object source,
      string text
      )
      {
      log.Fatal($"{source}: {text}");
      log.Fatal("Program done.");
      }

    }
  }
