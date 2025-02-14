using KiConsoleFramework.Repo.Interface;

namespace KiConsoleFramework.Repo
  {
  public class ClassOneRepo : ClassMysqlRepo, IClassOneRepo
    {
    void IClassOneRepo.Delete(string username)
      {
      throw new System.NotImplementedException();
      }

    bool IClassOneRepo.Get
      (
      string username,
      out string encoded_password,
      out bool be_stale_password,
      out string password_reset_email_address,
      out bool be_active,
      out uint num_unsuccessful_login_attempts,
      out string last_login
      )
      {
      throw new System.NotImplementedException();
      }

    string IClassOneRepo.IdOf(string username)
      {
      throw new System.NotImplementedException();
      }
    }
  }
