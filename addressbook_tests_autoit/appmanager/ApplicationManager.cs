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
            WindowWait(WinTitle);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
         public void WindowWait(string window)
        {
            aux.WinWait(window);
            aux.WinActivate(window);
            aux.WinWaitActive(window);
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
