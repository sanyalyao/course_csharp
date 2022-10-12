using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreationContactsTests : TestBase
    {        
        [Test]
        public void CreationContactsTest()
        {
            ContactData contact = new ContactData("First name", "Last name");
            app.Contacts.InitCreationOfNewContact()
                .FillContactForm(contact)
                .SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
        }
    }
}
