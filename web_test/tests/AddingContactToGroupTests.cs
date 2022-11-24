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
            app.Groups.CheckIfGroupsPresent(GenerateRandomString(10));
            app.Contacts.CheckIfContactsPresent(GenerateRandomString(10), GenerateRandomString(10));
            app.Contacts.CheckIsThereFreeContact(GenerateRandomString(10), GenerateRandomString(10));
            ContactData contactForGroup = app.Contacts.GetRelations().First().Key;
            GroupData groupForContact = app.Contacts.GetRelations().First().Value;
            List<ContactData> oldList = groupForContact.GetContacts();
            app.Contacts.AddContactToGroup(contactForGroup, groupForContact);
            List<ContactData> newList = groupForContact.GetContacts();
            oldList.Add(contactForGroup);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
