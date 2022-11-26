using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WinTitle = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper;
        private ContactHelper contactHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"C:\Users\qwert\Documents\Course\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinWait(WinTitle);
            aux.WinActivate(WinTitle);
            aux.WinWaitActive(WinTitle);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux
        {
            get { return aux; }
        }

        public GroupHelper Groups
        {
            get 
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }
}
