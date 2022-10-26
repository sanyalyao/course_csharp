using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            GroupData groupForRemove = new GroupData("removed group");
            if (! app.Groups.IsGroupPresent(groupForRemove).Select(x => x.Key).Single())
            {
                app.Groups.Create(groupForRemove);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(groupForRemove);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData removedGroup = oldGroups.Where(item => item.Name == groupForRemove.Name).Single();
            oldGroups.Remove(groupForRemove);
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
