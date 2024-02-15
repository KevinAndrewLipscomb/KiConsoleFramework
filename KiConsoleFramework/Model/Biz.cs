using KiConsoleFramework.Repo;
using System.Configuration;

namespace KiConsoleFramework.Model
  {
  /// <summary>
  /// The composition root of the application
  /// </summary>
  public class Biz
    {

    private static readonly ClassOneMySqlRepo classOneMysqlDb = new();

    public ClassOneBiz classOne = new
      (
      classOneDb_imp:classOneMysqlDb,
      appSettings_imp:ConfigurationManager.AppSettings
      );

    }
  }
