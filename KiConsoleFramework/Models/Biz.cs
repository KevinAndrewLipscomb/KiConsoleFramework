using KiConsoleFramework.Data;

namespace KiConsoleFramework.Models
  {
  /// <summary>
  /// The composite root of the application
  /// </summary>
  public class Biz
    {

    private static readonly ClassOneMysqlDb classOneMysqlDb = new();

    public ClassOneBiz classOne = new
      (
      classOneDb_imp:classOneMysqlDb
      );

    }
  }
