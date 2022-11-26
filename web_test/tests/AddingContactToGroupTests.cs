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
            KeyValuePair<ContactData, GroupData> pairContactGroup = app.Contacts.GetRelations().First();
            ContactData contactForGroup = pairContactGroup.Key;
            GroupData groupForContact = pairContactGroup.Value;
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
