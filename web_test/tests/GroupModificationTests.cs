using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void ModifyGroup()
        {
            GroupData newGroup = new GroupData("modified group");
            GroupData oldGroup = new GroupData("not modified group");
            if (!GroupData.GetAll().Select(item => item.Name).ToList().Contains(oldGroup.Name))
            {
                app.Groups.Create(oldGroup);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData groupForModify = oldGroups.Where(item => item.Name == oldGroup.Name).First();
            app.Groups.Modify(newGroup, groupForModify);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Where(item => item.Id == groupForModify.Id).Single().Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == groupForModify.Id)
                {
                    Assert.AreEqual(newGroup.Name, group.Name);
                }
            }
        }
    }
}
