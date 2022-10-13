using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Remove(int contactInQueue)
        {
            manager.Navigator.OpenHomePage();
            SelectContactInQueue(contactInQueue);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int contactInQueue, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            InitModify(contactInQueue);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper CreateNewContact(ContactData newContact)
        {
            manager.Navigator.OpenHomePage();
            InitCreationOfNewContact();
            FillContactForm(newContact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitModify(int contactInQueue)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{1 + contactInQueue}]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SelectContactInQueue(int contactInQueue)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{1 + contactInQueue}]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            return this;
        }
        public ContactHelper InitCreationOfNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}
