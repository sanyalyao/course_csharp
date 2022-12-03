using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class AdminHelper : HelperBase
    {
        private string baseURL;
        public AdminHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_page.php";
            List<AccountData> accounts = new List<AccountData>();
            var elements = driver.FindElement(By.ClassName("table-responsive")).FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));
            foreach (IWebElement element in elements)
            {
                string link = element.FindElement(By.TagName("a")).GetAttribute("href");
                Match match = Regex.Match(link, @"\d+$");
                accounts.Add(new AccountData()
                {
                    Name = element.FindElement(By.TagName("a")).Text,
                    Id = match.Value
                });
            }
            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + $"/manage_user_edit_page.php?user_id={account.Id}";
            driver.FindElement(By.CssSelector("input[type='submit'][value='Delete User']")).Click();
            driver.FindElement(By.CssSelector("input[type='submit'][value='Delete Account']")).Click();
        }

        public IWebDriver OpenAppAndLogin()
        {
            AccountData admin = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "/login_page.php";
            driver.FindElement(By.Id("username")).SendKeys(admin.Name);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            driver.FindElement(By.Id("password")).SendKeys(admin.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            return driver;
        }
    }
}
