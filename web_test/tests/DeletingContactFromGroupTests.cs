using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroup()
        {
            app.Groups.CheckIfGroupsPresent(GenerateRandomString(10));
            app.Contacts.CheckIfContactsPresent(GenerateRandomString(10), GenerateRandomString(10));
            app.Contacts.CheckIsThereBusyContact();
            ContactData contacWithGroup = ContactData.GetAll().Where(contact => contact.GetGroups().Count() > 0).First();
            GroupData groupWithContact = GroupData.GetAll().Where(group => group.GetContacts().Exists(contact => contact.Id == contacWithGroup.Id)).First();
            List<ContactData> oldList = groupWithContact.GetContacts();
            app.Contacts.DeleteContactFromGroup(contacWithGroup, groupWithContact);
            List<ContactData> newList = groupWithContact.GetContacts();
            oldList.Remove(contacWithGroup);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
