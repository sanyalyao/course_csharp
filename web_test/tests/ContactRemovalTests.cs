using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void RemoveContact()
        {
            ContactData contactForRemove = new ContactData("removed First name", "removed Last name");
            if (! (from person in ContactData.GetAll() select new { person.FirstName, person.LastName })
                .Contains(new { contactForRemove.FirstName, contactForRemove.LastName })
                )
            {
                app.Contacts.CreateNewContact(contactForRemove);
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData removedContact = oldContacts.Where(person => person.LastName == contactForRemove.LastName && person.FirstName == contactForRemove.FirstName).First();
            app.Contacts.Remove(removedContact);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Remove(removedContact);
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
