using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class ModificationContactTests : TestBase
    {
        [Test]
        public void ModifyContact()
        {
            ContactData modifiedContact = new ContactData()
            {
                Firstname = GenerateRandomString(5),
            };
            if (app.Contacts.GetContactList().Count() == 0)
            {
                app.Contacts.CreateNewContact(new ContactData()
                {
                    Id = GenerateRandomIdentifier(),
                    Firstname = GenerateRandomString(5)
                });
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldContact = oldContacts[0];
            app.Contacts.ModifyContact(modifiedContact, 0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Where(x => x.Id == oldContact.Id).ToList().ForEach(x => x.Firstname = modifiedContact.Firstname);
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            foreach (ContactData contact in oldContacts)
            {
                foreach (ContactData newContact in newContacts)
                {
                    if (contact.Id == newContact.Id)
                    {
                        Assert.AreEqual(newContact.Firstname, contact.Firstname);
                    }
                }
            }
        }
    }
}
