using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> contactCache = null;

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index - 1].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = String.Join("", cells[4].FindElements(By.TagName("a")).Select(email => email.Text));
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }

        public ContactData GetContactInformationFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitModify(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomeTelephone = homePhone,
                Mobile = mobilePhone,
                WorkTelephone = workPhone
            };
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            if (IsContactPresent(contact).Select(x => x.Key).Single())
            {
                SelectContactInQueue(IsContactPresent(contact).Select(x => x.Value).Single());
                RemoveContact();
                manager.Navigator.ReturnToHomePage();
            }

        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElement(By.Id("maintable")).FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElements(By.TagName("td"))[2].Text, element.FindElements(By.TagName("td"))[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData> (contactCache);
        }

        public void Modify(ContactData newData, ContactData oldData)
        {
            if (IsContactPresent(oldData).Select(x => x.Key).Single())
            {
                manager.Navigator.OpenHomePage();
                InitModify(IsContactPresent(oldData).Select(x => x.Value).Single());
                FillContactForm(newData);
                SubmitContactModification();
                manager.Navigator.ReturnToHomePage();
            }
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

        public int GetContactCount()
        {
            return driver.FindElement(By.Id("maintable")).FindElements(By.Name("entry")).Count;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);

            //driver.FindElement(By.Name("middlename")).Clear();
            //driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);

            //nickname

            //company

            //title

            //address

            //telephone
            //home
            //mobile
            //work
            //fax

            //email

            //email-2

            //email-3

            //homepage

            //birthday
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.BirthdayDate.date.ToString());
            //driver.FindElement(By.XPath($"//option[@value='{contact.BirthdayDate.date}']")).Click();
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.BirthdayDate.month);
            //driver.FindElement(By.XPath($"//option[@value='{contact.BirthdayDate.month}']")).Click();
            //driver.FindElement(By.Name("byear")).Click();
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys(contact.BirthdayDate.year.ToString());

            //Anniversary
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.AnniversaryDate.date.ToString());
            //driver.FindElement(By.XPath($"//div[@id='content']/form/select[3]/option[{2 + contact.AnniversaryDate.date}]")).Click();
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.AnniversaryDate.month);
            //driver.FindElement(By.XPath($"//div[@id='content']/form/select[4]/option[{1 + DateTime.ParseExact(contact.AnniversaryDate.month, "MMMM", CultureInfo.CurrentCulture).Month}]")).Click();
            //driver.FindElement(By.Name("ayear")).Click();
            //driver.FindElement(By.Name("ayear")).Clear();
            //driver.FindElement(By.Name("ayear")).SendKeys(contact.AnniversaryDate.year.ToString());

            //group

            //secondary address

            //secondary home

            //secondary notes

            return this;
        }
        public ContactHelper InitCreationOfNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public Dictionary<bool,int> IsContactPresent(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> entries = driver.FindElement(By.Id("maintable")).FindElements(By.Name("entry"));
            List<IWebElement> tdElements = new List<IWebElement>();
            IList<KeyValuePair<string, string>> elements = new List<KeyValuePair<string, string>>();
            Dictionary<bool, int> result = new Dictionary<bool, int>();
            bool trueOrFalse = false;
            int numberOfEntry = 0;
            for (int i = 0; i < entries.Count(); i++)
            {
                tdElements.Clear();
                elements.Clear();
                tdElements.AddRange(entries[i].FindElements(By.TagName("td")));
                for (int j = 0; j < tdElements.Count - 1; j++)
                {
                    elements.Add(new KeyValuePair<string, string>(tdElements[j].Text, tdElements[j + 1].Text));
                    foreach (KeyValuePair<string, string> element in elements)
                    {
                        if (element.Key.ToLower() == contact.LastName.ToLower() && element.Value.ToLower() == contact.FirstName.ToLower())
                        {
                            trueOrFalse = true;
                            numberOfEntry = i + 1;
                        }
                    }
                }
            }
            result.Add(trueOrFalse, numberOfEntry);
            return result;
        }
    }
}
