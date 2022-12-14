using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ContactRemovingTests : TestBase
    {
        [Test]
        public void RemoveContact()
        {
            if (app.Contacts.GetContactList().Count() == 0)
            {
                app.Contacts.CreateNewContact(new ContactData() 
                { 
                    Id = GenerateRandomIdentifier(),
                    Firstname = GenerateRandomString(5)
                });
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contactForRemove = oldContacts[0];
            app.Contacts.RemoveContact(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, contactForRemove.Id);
            }
        }
    }
}
