using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldListGroups = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();
            app.Contacts.AddContactToGroup(contact, group);
            List<ContactData> newListGroups = group.GetContacts();
            oldListGroups.Add(contact);
            oldListGroups.Sort();
            newListGroups.Sort();
            Assert.AreEqual(oldListGroups, newListGroups);
        }
    }
}
