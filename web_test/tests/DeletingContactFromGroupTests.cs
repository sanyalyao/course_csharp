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
            if (GroupData.GetAll().Count() == 0)
            {
                GroupData group = new GroupData(GenerateRandomString(10));
                app.Groups.Create(group);
            }
            if (ContactData.GetAll().Count() == 0)
            {
                ContactData contact = new ContactData(GenerateRandomString(10), GenerateRandomString(10));
                app.Contacts.CreateNewContact(contact);
            }

            List<KeyValuePair<string, string>> listOfRelationsDB = app.Contacts.GetRelations();

            if (listOfRelationsDB.Count() == 0)
            {
                List<KeyValuePair<string, string>> myListOfRelations = new List<KeyValuePair<string, string>>();
                foreach (ContactData contact in ContactData.GetAll())
                {
                    foreach (GroupData group in GroupData.GetAll())
                    {
                        KeyValuePair<string, string> relation = new KeyValuePair<string, string>(contact.Id, group.Id);
                        myListOfRelations.Add(relation);
                    }
                }

                KeyValuePair<string, string> contactNotInGroup = myListOfRelations.First();
                ContactData contactForGroup = ContactData.GetAll().Where(contact => contact.Id == contactNotInGroup.Key).First();
                GroupData groupForContact = GroupData.GetAll().Where(group => group.Id == contactNotInGroup.Value).First();
                app.Contacts.AddContactToGroup(contactForGroup, groupForContact);

                KeyValuePair<string, string> relationForRemoving = app.Contacts.GetRelations().First();
                ContactData contactFromGroup = ContactData.GetAll().Where(contact => contact.Id == relationForRemoving.Key).First();
                GroupData groupFromContact = GroupData.GetAll().Where(group => group.Id == relationForRemoving.Value).First();
                List<ContactData> oldList = groupFromContact.GetContacts();
                app.Contacts.DeleteContactFromGroup(contactFromGroup, groupFromContact);
                List<ContactData> newList = groupFromContact.GetContacts();
                oldList.Remove(contactFromGroup);
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(oldList, newList);
            }

            else
            {
                KeyValuePair<string, string> relationForRemoving = app.Contacts.GetRelations().First();
                ContactData contactFromGroup = ContactData.GetAll().Where(contact => contact.Id == relationForRemoving.Key).First();
                GroupData groupFromContact = GroupData.GetAll().Where(group => group.Id == relationForRemoving.Value).First();
                List<ContactData> oldList = groupFromContact.GetContacts();
                app.Contacts.DeleteContactFromGroup(contactFromGroup, groupFromContact);
                List<ContactData> newList = groupFromContact.GetContacts();
                oldList.Remove(contactFromGroup);
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(oldList, newList);
            }
        }
    }
}
