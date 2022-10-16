using NUnit.Framework;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ModifyContact()
        {
            ContactData modifiedContact = new ContactData("modified First name", "modified Last name");
            modifiedContact.MiddleName = "modified Middle name";
            ContactData oldContact = new ContactData("another First name", "another Last name");
            if (! app.Contacts.IsContactPresent(oldContact).Select(x => x.Key).Single())
            {
                app.Contacts.CreateNewContact(oldContact);
            }
            app.Contacts.Modify(modifiedContact, oldContact);
        }
    }
}
