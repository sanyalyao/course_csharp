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
            GroupData groupForRemove = new GroupData("removed group");
            if (!GroupData.GetAll().Select(item => item.Name).ToList().Contains(groupForRemove.Name))
            {
                app.Groups.Create(groupForRemove);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData removedGroup = oldGroups.Where(item => item.Name == groupForRemove.Name).First();
            app.Groups.Remove(removedGroup);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Remove(removedGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(removedGroup.Id, group.Id);
            }
        }
    }
}
