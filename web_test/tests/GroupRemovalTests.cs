using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            if (GroupData.GetAll().Count() == 0)
            {
                app.Groups.Create(new GroupData(GenerateRandomString(5)));
            }
            GroupData groupForRemove = GroupData.GetAll()[0];
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Remove(groupForRemove);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(groupForRemove.Id, group.Id);
            }
        }
    }
}
