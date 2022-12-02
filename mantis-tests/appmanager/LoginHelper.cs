using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                LogOut();
            }
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
        }

        private bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLoggetUserName() == account.Name;
        }

        private bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("user-info"));
        }
        private string GetLoggetUserName()
        {
            return driver.FindElement(By.ClassName("user-info")).Text;
        }

        public void LogOut()
        {
            driver.FindElement(By.ClassName("user-info")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
