using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class CreationContactsTests : TestBase
    {        
        [Test]
        public void CreationContactsTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Contacts.InitCreationOfNewContact();
            ContactData contact = new ContactData("First name", "Last name");
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.ReturnToHomePage();
        }
    }
}
