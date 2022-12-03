using OpenQA.Selenium;
using System;

namespace mantis_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenMainPage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void OpenManageMenu()
        {
            driver.FindElement(By.LinkText("Manage")).Click();
        }

        public void OpenManageProjectsPage()
        {
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

        public void OpenManageUsersPage()
        {
            driver.FindElement(By.LinkText("Manage Users")).Click();
        }
    }
}
