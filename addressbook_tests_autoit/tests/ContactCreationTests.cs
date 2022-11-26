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
                Firstname = "firstname"
            };
            app.Contacts.CreateNewContact(newContact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}
