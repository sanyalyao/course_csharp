using System;
using System.Collections.Generic;


namespace addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    {
        public static string WinContactEditor = "Contact Editor";
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            int count = Int32.Parse(aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d55").Split('/')[1]);
            for (int i = 0; i < count; i++)
            {
                string item = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d55");
                list.Add(new ContactData() { Firstname = item });
                aux.Send("{DOWN}");
            }
            for (int i = 0; i < count; i++)
            {
                aux.Send("{UP}");
            }
            return list;
        }

        internal void RemoveContact(int index)
        {
            if (index == 0)
            {
                aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d59");
                aux.Send("{LEFT}{ENTER}");
                aux.WinWait("", "", 2);
            }
            else
            {
                for (int i = 0; i <= index - 1; i++)
                {
                    aux.Send("{DOWN}");
                }
                aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d59");
                aux.Send("{LEFT}{ENTER}");
                aux.WinWait("", "", 2);
            }
        }

        public void CreateNewContact(ContactData newContact)
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait(WinContactEditor);
            aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d516");
            aux.Send(newContact.Firstname);
            aux.ControlClick(WinContactEditor, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait("", "", 2);
        }
    }
}
