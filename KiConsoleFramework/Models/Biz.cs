using KiConsoleFramework.Data;
using System.Configuration;

namespace KiConsoleFramework.Models
  {
  /// <summary>
  /// The composition root of the application
  /// </summary>
  public class Biz
    {

    private static readonly ClassOneMysqlDb classOneMysqlDb = new();

    public ClassOneBiz classOne = new
      (
      classOneDb_imp:classOneMysqlDb,
      appSettings_imp:ConfigurationManager.AppSettings
      );

    }
  }
