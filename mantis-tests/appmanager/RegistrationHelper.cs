using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper (ApplicationManager manager) : base(manager)
        { }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            Proceed();
        }

        private void Proceed()
        {
            driver.FindElement(By.LinkText("Proceed")).Click();
        }

        private void OpenMainPage()
        {
            manager.Navigation.OpenMainPage();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.LinkText("Signup for a new account")).Click();
        }
        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);

        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input[type='submit'][value='Signup']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(d => d.FindElements(By.LinkText("Proceed")).Count() > 0);
        }
    }
}
