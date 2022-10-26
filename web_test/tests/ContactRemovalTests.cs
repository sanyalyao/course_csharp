using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveContact()
        {
            ContactData contactForRemove = new ContactData("removed First name", "removed Last name");
            if (! app.Contacts.IsContactPresent(contactForRemove).Select(x => x.Key).Single())
            {
                app.Contacts.CreateNewContact(contactForRemove);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(contactForRemove);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData removedContact = oldContacts.Where(item => item.LastName == contactForRemove.LastName && item.FirstName == contactForRemove.FirstName).Single();
            oldContacts.Remove(contactForRemove);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(removedContact.Id, contact.Id);
            }
        }
    }
}
