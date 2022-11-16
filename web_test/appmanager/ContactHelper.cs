using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

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
            string allEmails = cells[4].Text;
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
            InitModifyByCount(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homePhoneSecondary = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomeTelephone = homePhone,
                Mobile = mobilePhone,
                WorkTelephone = workPhone,
                SecondaryHomePhone = homePhoneSecondary
            };
        }

        public ContactData GetContactInformationFromPropertyPage(int index)
        {
            GoToPropertiesOfContact(index);
            string allInformation = driver.FindElement(By.Id("content")).Text;
            return new ContactData("", "")
            {
                AllInformation = allInformation
            };
        }

        public ContactData GetDetailedContactInformationFromForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitModifyByCount(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string companyName = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).Text;
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).FindElement(By.TagName("option")).Text;
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).FindElement(By.TagName("option")).Text;
            string amonth = driver.FindElement(By.Name("amonth")).FindElement(By.TagName("option")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string addressSecondary = driver.FindElement(By.Name("address2")).Text;
            string homePhoneSecondary = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).Text;
            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                Nickname = nickname,
                Company = companyName,
                Title = title,
                Address = address,
                HomeTelephone = homePhone,
                Mobile = mobilePhone,
                WorkTelephone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                Bday = bday == "-" ? "" : bday,
                Bmonth = bmonth == "-" ? "" : bmonth,
                Byear = byear,
                Aday = aday == "-" ? "" : aday,
                Amonth = amonth == "-" ? "" : amonth,
                Ayear = ayear,
                SecondaryAddress = addressSecondary,
                SecondaryHomePhone = homePhoneSecondary,
                SecondaryNotes = notes
            };
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContactById(contact.Id);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();
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
            manager.Navigator.OpenHomePage();
            InitModifyById(oldData.Id);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
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

        public ContactHelper InitModifyByCount(int contactInQueue)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{1 + contactInQueue}]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper InitModifyById(string id)
        {
            driver.FindElement(By.XPath($"//a[@href=\"edit.php?id={id}\"]")).Click();
            return this;
        }

        public ContactHelper SelectContactInQueue(int contactInQueue)
        {
            driver.FindElement(By.XPath($"//table[@id='maintable']/tbody/tr[{1 + contactInQueue}]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectContactById(string id)
        {
            driver.FindElement(By.XPath($"//input[@name=\"selected[]\" and @value=\"{id}\"]")).Click();
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
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName == null ? "" : contact.FirstName);

            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName == null ? "" : contact.MiddleName);

            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName == null ? "" : contact.LastName);

            //nickname
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname == null ? "" : contact.Nickname);

            //company
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company == null ? "" : contact.Company);

            //title
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title == null ? "" : contact.Title);

            //address
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address == null ? "" : contact.Address);

            //telephone
            //home
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.HomeTelephone == null ? "" : contact.HomeTelephone);

            //mobile
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile == null ? "" : contact.Mobile);

            //work
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.WorkTelephone == null ? "" : contact.WorkTelephone);

            //fax
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax == null ? "" : contact.Fax);

            //email
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email == null ? "" : contact.Email);

            //email-2
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2 == null ? "" : contact.Email2);

            //email-3
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3 == null ? "" : contact.Email3);

            //homepage
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage == null ? "" : contact.Homepage);

            //birthday
            if (contact.Bday != null)
            {
                driver.FindElement(By.Name("bday")).Click();
                new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
                driver.FindElement(By.XPath($"//option[@value='{contact.Bday}']")).Click();
            }
            if (contact.Bmonth != null)
            {
                driver.FindElement(By.Name("bmonth")).Click();
                new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
                driver.FindElement(By.XPath($"//option[@value='{contact.Bmonth}']")).Click();
            }
            if (contact.Byear != null)
            {
                driver.FindElement(By.Name("byear")).Click();
                driver.FindElement(By.Name("byear")).Clear();
                driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            }

            //Anniversary
            if (contact.Aday != null)
            {
                driver.FindElement(By.Name("aday")).Click();
                new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
                driver.FindElement(By.XPath($"//div[@id='content']/form/select[3]/option[{2 + Int32.Parse(contact.Aday)}]")).Click();
            }
            if (contact.Amonth != null)
            {
                driver.FindElement(By.Name("amonth")).Click();
                new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
                driver.FindElement(By.XPath($"//div[@id='content']/form/select[4]/option[{1 + DateTime.ParseExact(contact.Amonth, "MMMM", CultureInfo.CurrentCulture).Month}]")).Click();
            }
            if (contact.Ayear != null)
            {
                driver.FindElement(By.Name("ayear")).Click();
                driver.FindElement(By.Name("ayear")).Clear();
                driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            }

            //secondary address
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.SecondaryAddress == null ? "" : contact.SecondaryAddress);

            //secondary home
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.SecondaryHomePhone == null ? "" : contact.SecondaryHomePhone);

            //secondary notes
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.SecondaryNotes == null ? "" : contact.SecondaryNotes);

            return this;
        }
        public ContactHelper InitCreationOfNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public void GoToPropertiesOfContact(int index)
        {
            manager.Navigator.OpenHomePage();
            driver.FindElements(By.Name("entry"))[index - 1].FindElements(By.TagName("td"))[6].Click();
        }
    }
}
