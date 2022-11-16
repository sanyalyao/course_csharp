using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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

        public static IEnumerable<ContactData> ContactsDataFromXml()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader("contacts.xml"));

        }

        public static IEnumerable<ContactData> ContactsDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText("contacts.json"));
        }

        [Test, TestCaseSource("ContactsDataFromJson")]
        public void ContactCreationTest(ContactData newContact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            app.Contacts.CreateNewContact(newContact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
