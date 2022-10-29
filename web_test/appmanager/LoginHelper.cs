using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {        
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData accountdata)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(accountdata))
                {
                    return;
                }
                LogOut();
            }
            Type(By.Name("user"), accountdata.Username);
            Type(By.Name("pass"), accountdata.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData accountdata)
        {
            return IsLoggedIn() && GetLoggetUserName() == accountdata.Username;
        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
