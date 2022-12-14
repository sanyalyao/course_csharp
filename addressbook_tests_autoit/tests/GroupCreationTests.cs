using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = GenerateRandomString(5)
            };
            app.Groups.CreateNewGroup(newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            foreach (GroupData group in newGroups)
            {
                foreach (GroupData oldGroup in oldGroups)
                {
                    if (oldGroup.Name == group.Name)
                    {
                        Assert.AreEqual(oldGroup.Name, group.Name);
                    }
                }
            }
        }
    }
}
