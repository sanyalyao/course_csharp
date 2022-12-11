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
            if (ContactData.GetAll().Count() == 0)
            {
                app.Contacts.CreateNewContact(new ContactData(GenerateRandomString(5), GenerateRandomString(5)));
            }
            ContactData contactForRemove = ContactData.GetAll()[0];
            List<ContactData> oldContacts = ContactData.GetAll();
            app.Contacts.Remove(contactForRemove);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contactForRemove.Id, contact.Id);
            }
        }
    }
}
