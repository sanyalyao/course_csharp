using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ModifyContact()
        {
            ContactData modifiedContact = new ContactData(GenerateRandomString(5), GenerateRandomString(5));
            if (ContactData.GetAll().Count() == 0)
            {
                app.Contacts.CreateNewContact(new ContactData(GenerateRandomString(5), GenerateRandomString(5)));
            }
            ContactData oldContact = ContactData.GetAll()[0];
            List<ContactData> oldContacts = ContactData.GetAll();
            app.Contacts.Modify(modifiedContact, oldContact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = modifiedContact.FirstName;
            oldContacts[0].LastName = modifiedContact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContact.Id)
                {
                    Assert.AreEqual(modifiedContact.LastName, contact.LastName);
                    Assert.AreEqual(modifiedContact.FirstName, contact.FirstName);
                }
            }
        }
    }
}
