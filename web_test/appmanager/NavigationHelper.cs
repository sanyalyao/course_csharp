using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoToNextBirthdaysPage()
        {
            driver.FindElement(By.LinkText("next birthdays")).Click();
        }
        public void GoToPrintAllPage()
        {
            driver.FindElement(By.LinkText("print all")).Click();
        }
        public void GoToPrintPhonesPage()
        {
            driver.FindElement(By.LinkText("print phones")).Click();
        }
        public void GoToMapPage()
        {
            driver.FindElement(By.LinkText("map")).Click();
        }
        public void GoToExportPage()
        {
            driver.FindElement(By.LinkText("export")).Click();
        }
        public void GoToImportPage()
        {
            driver.FindElement(By.LinkText("import")).Click();
        }
    }
}
