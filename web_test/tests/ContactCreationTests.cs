using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            ContactData newContact = new ContactData("new First name", "new Last name");
            newContact.MiddleName = "new Middle name";
            app.Contacts.CreateNewContact(newContact);            
        }
    }
}
