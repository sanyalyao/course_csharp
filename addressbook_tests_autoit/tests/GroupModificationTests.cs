using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void ModifyGroup()
        {
            if (app.Groups.GetGroupList().Count() == 0)
            {
                app.Groups.CreateNewGroup(new GroupData()
                {
                    Name = GenerateRandomString(5)
                });
            }
            List<GroupData> oldGroups= app.Groups.GetGroupList();
            GroupData oldGroup = oldGroups[0];
            GroupData modifiedGroup = new GroupData()
            {
                Name = GenerateRandomString(5)
            };
            app.Groups.ModifyGroup(modifiedGroup, 0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Where(x => x.Name == oldGroup.Name).ToList().ForEach(x => x.Name = modifiedGroup.Name);
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            foreach (GroupData group in oldGroups)
            {
                foreach (GroupData newGroup in newGroups)
                {
                    if (group.Name == newGroup.Name)
                    {
                        Assert.AreEqual(newGroup.Name, group.Name);
                    }
                }
            }
        }
    }
}
