using NUnit.Framework;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            GroupData group = new GroupData("g");
            if (! app.Groups.IsGroupPresent(group).Select(x => x.Key).Single())
            {
                app.Groups.Create(group);
            }
            app.Groups.Remove(group);
        }
    }
}
