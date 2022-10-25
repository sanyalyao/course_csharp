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
            GroupData group = new GroupData("removed group");
            if (! app.Groups.IsGroupPresent(group).Select(x => x.Key).Single())
            {
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }
    }
}
