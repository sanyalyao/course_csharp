using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void RemoveGroupTest()
        {
            if (app.Groups.GetGroupList().Count() == 0 || app.Groups.GetGroupList().Count() == 1)
            {
                app.Groups.CreateNewGroup(new GroupData() { Name = GenerateRandomString(5)});
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupForRemove = oldGroups[0];
            app.Groups.RemoveGroup(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Name, groupForRemove.Name);
            }
        }
    }
}
