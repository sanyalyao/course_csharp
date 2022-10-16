using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {        
        [Test]
        public void ContactCreationTest()
        {
            ContactData newContact = new ContactData("new First name", "new Last name");
            newContact.MiddleName = "new Middle name";
            newContact.Address = "Address";
            newContact.Email3 = "email-3";
            newContact.BirthdayDate = new ContactData.Birthday(1, "March", 1990);
            newContact.AnniversaryDate = new ContactData.Anniversary(2, "February", 2000);
            app.Contacts.CreateNewContact(newContact);            
        }
    }
}
