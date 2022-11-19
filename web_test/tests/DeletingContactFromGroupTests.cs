using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldListGroups = group.GetContacts();
            ContactData contact = oldListGroups[0];
            app.Contacts.DeleteContactFromGroup(contact, group);
            List<ContactData> newListGroups = group.GetContacts();
            oldListGroups.Remove(contact);
            oldListGroups.Sort();
            newListGroups.Sort();
            Assert.AreEqual(oldListGroups, newListGroups);
        }
    }
}
