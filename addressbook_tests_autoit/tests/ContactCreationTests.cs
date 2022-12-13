using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void CreateContact()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData newContact = new ContactData()
            {
                Id = GenerateRandomIdentifier(),
                Title = GenerateRandomString(5),
                Firstname = GenerateRandomString(5),
                //Middlename = GenerateRandomString(5),
                //Lastname = GenerateRandomString(5),
                //Country = GenerateRandomString(5),
                //City = GenerateRandomString(5),
                //State = GenerateRandomString(5),
                //Zip = GenerateRandomZip(),
                //Address = GenerateRandomString(10),
                //Phone1 = GenerateRandomPhone(),
                //Phone2 = GenerateRandomPhone(),
                //Fax = GenerateRandomPhone(),
                //Mobile1 = GenerateRandomPhone(),
                //Mobile2 = GenerateRandomPhone(),
                //Web = GenerateRandomWebSite(),
                //Email1 = GenerateRandomEmail(),
                //Email2 = GenerateRandomEmail(),
                //Note = GenerateRandomString(15)
            };
            app.Contacts.CreateNewContact(newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            foreach (ContactData oldContact in oldContacts)
            {
                if (oldContact.Id == newContact.Id)
                {
                    Assert.AreEqual(newContact.Firstname, oldContact.Firstname);
                }
            }
        }
    }
}
