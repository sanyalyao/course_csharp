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
            return IsLoggedIn() && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == $"({accountdata.Username})";
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
