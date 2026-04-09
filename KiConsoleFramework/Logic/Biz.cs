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
  public partial class Biz
    {

    static Biz() // CONSTRUCTOR
      {
      var appBase = AppDomain.CurrentDomain.BaseDirectory;
      var ConnectionStringsFilePath = Path.Combine(appBase, "Config\\Sensitive\\connectionStrings.config");
      if (!File.Exists(ConnectionStringsFilePath))
        {
        var message = $"'{ConnectionStringsFilePath}' is missing. You may have to create it from scratch using '{appBase}Config\\Template\\connectionStrings.config' as a basis.";
        throw new Exception(message);
        }
      }

    public event Action<ObjectBiz> ObjectBizLoaded; // to be observed by the Controller to wire the ObjectBiz descendant up to the View

    internal void NotifyObjectBizLoaded(ObjectBiz objectBiz) => ObjectBizLoaded?.Invoke(objectBiz); // for the Biz constructor to call when it lazy-loads an ObjectBiz descendant, so that the Controller can wire it up to the View

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
