using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXml()
        {
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader("groups.xml"));

        }

        public static IEnumerable<GroupData> GroupDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText("groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJson")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDB()
        {
            foreach (ContactData contact in GroupData.GetAll()[0].GetContacts())
            {
                Console.Out.WriteLine(contact);
            }

            foreach (GroupData group in ContactData.GetAll()[0].GetGroups())
            {
                Console.Out.WriteLine(group);
            }
        }

    }
}
