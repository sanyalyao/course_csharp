using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ModifyContact()
        {
            ContactData modifiedContact = new ContactData("modified First name", "modified Last name");
            ContactData oldContact = new ContactData("ii First name", "ii Last name");
            if (! app.Contacts.IsContactPresent(oldContact).Select(x => x.Key).Single())
            {
                app.Contacts.CreateNewContact(oldContact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(modifiedContact, oldContact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData oldContactFromList = oldContacts.Where(item => item.FirstName == oldContact.FirstName && item.LastName == oldContact.LastName).Single();
            oldContacts.Where(item => item.FirstName == oldContact.FirstName && item.LastName == oldContact.LastName).ToList().ForEach(name =>
            {
                name.FirstName = modifiedContact.FirstName;
                name.LastName = modifiedContact.LastName;
            });
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactFromList.Id)
                {
                    Assert.AreEqual(modifiedContact.LastName, contact.LastName);
                    Assert.AreEqual(modifiedContact.FirstName, contact.FirstName);
                }
            }
        }
    }
}
