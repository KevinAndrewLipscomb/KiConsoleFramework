﻿using KiConsoleFramework.Models;
using KiConsoleFramework.Views;
using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace KiConsoleFramework
  {
  /// <summary>
  /// Performs such-and-such.  Can be invoked as a console application or as a Windows Service.
  /// </summary>
  [System.Runtime.Versioning.SupportedOSPlatform("windows")] // but may require modificaiton to run as a daemon via Mono
  partial class Program
    {

    static readonly private Biz biz = new();
      // COMPOSITION ROOT; exposes elements of the MODEL

    static private ClassOneInteraction classOneInteraction;

    /// <summary>
    /// Serves as the CONTROLLER
    /// </summary>
    /// <param name="args">Command line arguments</param>
    static void Main(string[] args)
      {

      classOneInteraction = new ClassOneInteraction();
        // An Interaction acts as a VIEW.

      try
        {
        if (Environment.UserInteractive)
          {
          //
          // running as console app
          //
          classOneInteraction.OnQuitCommanded += biz.classOne.Quit;
            // An Interaction used by the controller inside a loop must also expose BeQuitCommanded.  If any parameters are needed in
            // addition to the command line args, the Interaction's constructor prompts the user for, and returns, such parameters.  

          Work(args);
            // This blocks until the biz layer (the model) is complete.  The model observes the interaction (the view), which offers
            // the user a way to command a quit, so the model may complete on its own or quit at the behest of the user.

          Stop();
          }
        else
          {
          //
          // running as service
          //
          using var service = new Service();
          ServiceBase.Run(service);
          }
        }
      catch (Exception e)
        {
        classOneInteraction.ShowFailure(Process.GetCurrentProcess().ProcessName,$"{e}");
        }

      }

    static private void Work(string[] args)
      {
      //
      // Wire up the view to observe each public ObjectBiz field/class in the model.
      //
      foreach(var field_info in typeof(Biz).GetFields())
        {
        if (field_info.FieldType.IsSubclassOf(typeof(ObjectBiz)))
          {
          (field_info.GetValue(biz) as ObjectBiz).OnProgress += classOneInteraction.ShowProgress;
          (field_info.GetValue(biz) as ObjectBiz).OnCompletion += classOneInteraction.ShowCompletion;
          (field_info.GetValue(biz) as ObjectBiz).OnDebug += classOneInteraction.ShowDebug;
          (field_info.GetValue(biz) as ObjectBiz).OnWarning += classOneInteraction.ShowWarning;
          (field_info.GetValue(biz) as ObjectBiz).OnError += classOneInteraction.ShowError;
          (field_info.GetValue(biz) as ObjectBiz).OnFailure += classOneInteraction.ShowFailure;
          }
        }
      //
      // Execute the business processing.
      //
      biz.classOne.Process
        (
        parameterOne:classOneInteraction.ParameterOne,
        parameterTwo:classOneInteraction.ParameterTwo
        );
      }

    static private void Stop()
      {
      // onstop code here
      }

    }
  }
