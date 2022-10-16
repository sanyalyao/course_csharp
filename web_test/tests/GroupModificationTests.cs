using NUnit.Framework;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void ModifyGroup()
        {
            GroupData newGroup = new GroupData("NEW NAME");
            GroupData oldGroup = new GroupData("ff");
            if (! app.Groups.IsGroupPresent(oldGroup).Select(x => x.Key).Single())
            {
                app.Groups.Create(oldGroup);
            }
            app.Groups.Modify(newGroup, oldGroup);
        }
    }
}
