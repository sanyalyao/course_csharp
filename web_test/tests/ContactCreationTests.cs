using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(5), GenerateRandomString(5))
                {
                    MiddleName = GenerateRandomString(5),
                    Nickname = GenerateRandomString(5),
                    Company = GenerateRandomString(5),
                    Title = GenerateRandomString(5),
                    Address = GenerateRandomString(10),
                    HomeTelephone = GenerateRandomPhone(),
                    WorkTelephone = GenerateRandomPhone(),
                    Mobile = GenerateRandomPhone(),
                    Fax = GenerateRandomPhone(),
                    Email = GenerateRandomEmail(),
                    Email2 = GenerateRandomEmail(),
                    Email3 = GenerateRandomEmail(),
                    Homepage = GenerateRandomWebSite(),
                    Bday = GetRandomDay(),
                    Bmonth = GetRandomMonth(),
                    Byear = GenerateRandomYear(),
                    Aday = GetRandomDay(),
                    Amonth = GetRandomMonth(),
                    Ayear = GenerateRandomYear(),
                    SecondaryAddress = GenerateRandomString(10),
                    SecondaryHomePhone = GenerateRandomPhone(),
                    SecondaryNotes = GenerateRandomString(15)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData newContact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.CreateNewContact(newContact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
