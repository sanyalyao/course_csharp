using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        public AccountData adminAccount = new AccountData()
        {
            Name = "administrator",
            Password = "root"
        };

        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(adminAccount);
        }
    }
}
