using KiConsoleFramework.Repo;
using KiConsoleFramework.Repo.Interface;
using System.Configuration;

namespace KiConsoleFramework.Model
  {
  /// <summary>
  /// The composition root of the application
  /// </summary>
  public class Biz
    {

    static readonly private IClassOneRepo classOneRepo = new ClassOneMysqlRepo // or ClassOneFileRepo
      (
      );

    public ClassOneBiz classOne = new
      (
      appSettings_imp:ConfigurationManager.AppSettings,
      repo_imp:classOneRepo
      );

    }
  }
