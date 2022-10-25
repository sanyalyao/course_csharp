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
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Where(item => item.FirstName == oldContact.FirstName && item.LastName == oldContact.LastName).ToList().ForEach(name =>
            {
                name.FirstName = modifiedContact.FirstName;
                name.LastName = modifiedContact.LastName;
            });
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
