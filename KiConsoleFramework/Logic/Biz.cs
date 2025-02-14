using KiConsoleFramework.Repo;
using KiConsoleFramework.Repo.Interface;
using System;
using System.Configuration;
using System.IO;

namespace KiConsoleFramework.Logic
  {
  /// <summary>
  /// The composition root of the application
  /// </summary>
  public class Biz
    {

    static Biz()
      {
      var appBase = AppDomain.CurrentDomain.BaseDirectory;
      var ConnectionStringsFilePath = Path.Combine(appBase, "Config\\Sensitive\\connectionStrings.config");
      if (!File.Exists(ConnectionStringsFilePath))
        {
        var message = $"'{ConnectionStringsFilePath}' is missing. You may have to create it from scratch using '{appBase}Config\\Template\\connectionStrings.config' as a basis.";
        throw new Exception(message);
        }
      }

    public ClassOneBiz classOne = new
      (
      appSettings_imp: ConfigurationManager.AppSettings,
      repo_imp: classOneRepo
      );

    static readonly private IClassOneRepo classOneRepo = new ClassOneRepo
      (
      );

    }
  }
