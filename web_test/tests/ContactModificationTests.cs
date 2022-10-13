using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("another First name", "another Last name");
            newData.MiddleName = "another Middle name";
            app.Contacts.Modify(1, newData);
        }
    }
}
