using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("new name");
            newData.Header = "new header";
            newData.Footer = "new footer";
            app.Groups.Modify(1, newData);
        }

        public void EmptyGroupModificationTest()
        {
            GroupData newData = new GroupData("Name Name");
            newData.Header = "";
            newData.Footer = "";
            app.Groups.Modify(1, newData);
        }
    }
}
