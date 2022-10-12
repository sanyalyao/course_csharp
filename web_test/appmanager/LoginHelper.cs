using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {        
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData accountdata)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(accountdata.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
