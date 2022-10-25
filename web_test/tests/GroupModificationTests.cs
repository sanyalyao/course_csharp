using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void ModifyGroup()
        {
            GroupData newGroup = new GroupData("modified group");
            GroupData oldGroup = new GroupData("not modified group");
            if (! app.Groups.IsGroupPresent(oldGroup).Select(x => x.Key).Single())
            {
                app.Groups.Create(oldGroup);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(newGroup, oldGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Where(item => item.Name == oldGroup.Name).Single().Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
