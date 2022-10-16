using NUnit.Framework;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveContact()
        {
            ContactData contact = new ContactData("new First name", "new Last name");
            if (! app.Contacts.IsContactPresent(contact).Select(x => x.Key).Single())
            {
                app.Contacts.CreateNewContact(contact);
            }
            app.Contacts.Remove(contact);
        }
    }
}
