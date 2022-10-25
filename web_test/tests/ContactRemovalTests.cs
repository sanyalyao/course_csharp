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
            ContactData contact = new ContactData("removed First name", "removed Last name");
            if (! app.Contacts.IsContactPresent(contact).Select(x => x.Key).Single())
            {
                app.Contacts.CreateNewContact(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Remove(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
