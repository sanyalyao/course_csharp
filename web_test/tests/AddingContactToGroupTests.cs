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
            List<KeyValuePair<string, string>> myListOfRelations = new List<KeyValuePair<string, string>>();
            foreach (ContactData contact in ContactData.GetAll())
            {
                foreach (GroupData group in GroupData.GetAll())
                {
                    KeyValuePair<string, string> relation = new KeyValuePair<string, string>(contact.Id, group.Id);
                    myListOfRelations.Add(relation);
                }
            }

            if (listOfRelationsDB.Count() == 0)
            {
                KeyValuePair<string, string> contactNotInGroup = myListOfRelations.First();
                ContactData contactForGroup = ContactData.GetAll().Where(contact => contact.Id == contactNotInGroup.Key).First();
                GroupData groupForContact = GroupData.GetAll().Where(group => group.Id == contactNotInGroup.Value).First();
                List<ContactData> oldList = groupForContact.GetContacts();
                app.Contacts.AddContactToGroup(contactForGroup, groupForContact);
                List<ContactData> newList = groupForContact.GetContacts();
                oldList.Add(contactForGroup);
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(oldList, newList);
            }

            else if (myListOfRelations.Except(listOfRelationsDB.Select(relations => relations)).Count() == 0)
            {

                GroupData mewGroup = new GroupData(GenerateRandomString(10));
                app.Groups.Create(mewGroup);

                foreach (ContactData contact in ContactData.GetAll())
                {
                    foreach (GroupData group in GroupData.GetAll())
                    {
                        KeyValuePair<string, string> relation = new KeyValuePair<string, string>(contact.Id, group.Id);
                        myListOfRelations.Add(relation);
                    }
                }

                KeyValuePair<string, string> contactNotInGroup = myListOfRelations.Distinct().Except(listOfRelationsDB.Select(relations => relations)).First();
                ContactData contactForGroup = ContactData.GetAll().Where(contact => contact.Id == contactNotInGroup.Key).First();
                GroupData groupForContact = GroupData.GetAll().Where(group => group.Id == contactNotInGroup.Value).First();
                List<ContactData> oldList = groupForContact.GetContacts();
                app.Contacts.AddContactToGroup(contactForGroup, groupForContact);
                List<ContactData> newList = groupForContact.GetContacts();
                oldList.Add(contactForGroup);
                oldList.Sort();
                newList.Sort();
                Assert.AreEqual(oldList, newList);
            }

            else
            {
                KeyValuePair<string, string> contactNotInGroup = myListOfRelations.Except(listOfRelationsDB.Select(relations => relations)).First();
                ContactData contactForGroup = ContactData.GetAll().Where(contact => contact.Id == contactNotInGroup.Key).First();
                GroupData groupForContact = GroupData.GetAll().Where(group => group.Id == contactNotInGroup.Value).First();
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
}
