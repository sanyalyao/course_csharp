using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void CompareInfoFromTableAndForm()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(1);
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(1);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void CompareInfoFromPropertiesAndForm()
        {
            ContactData fromPropertyPage = app.Contacts.GetContactInformationFromPropertyPage(1);
            ContactData fromForm = app.Contacts.GetDetailedContactInformationFromForm(1);
            Assert.AreEqual(fromPropertyPage, fromForm);
            Assert.AreEqual(fromPropertyPage.AllInformation, fromForm.AllInformation);
        }
    }
}
