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
            ContactData modifiedContact = new ContactData("modified First name", "modified Last name");
            ContactData oldContact = new ContactData("ii First name", "ii Last name");
            if (! (from person in ContactData.GetAll() select new { person.FirstName, person.LastName })
                .Contains(new { oldContact.FirstName, oldContact.LastName })
                )
            {
                app.Contacts.CreateNewContact(oldContact);
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContactFromDB = oldContacts.Where(person => person.FirstName == oldContact.FirstName && person.LastName == oldContact.LastName).First();
            app.Contacts.Modify(modifiedContact, oldContactFromDB);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Where(person => person.Id == oldContactFromDB.Id).Single().FirstName = modifiedContact.FirstName;
            oldContacts.Where(person => person.Id == oldContactFromDB.Id).Single().LastName = modifiedContact.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContactFromDB.Id)
                {
                    Assert.AreEqual(modifiedContact.LastName, contact.LastName);
                    Assert.AreEqual(modifiedContact.FirstName, contact.FirstName);
                }
            }
        }
    }
}
