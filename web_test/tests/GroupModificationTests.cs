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
            GroupData newGroup = new GroupData(GenerateRandomString(5));
            if (GroupData.GetAll().Count() == 0)
            {
                app.Groups.Create(new GroupData(GenerateRandomString(5)));
            }
            GroupData oldGroup = GroupData.GetAll()[0];
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Modify(newGroup, oldGroup);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldGroup.Id)
                {
                    Assert.AreEqual(newGroup.Name, group.Name);
                }
            }
        }
    }
}
