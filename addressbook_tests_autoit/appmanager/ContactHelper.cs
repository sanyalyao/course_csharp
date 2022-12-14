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
            WindowWait(WinTitle);
            List<ContactData> list = new List<ContactData>();
            int count = Int32.Parse(aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d55").Split('/')[1]);
            for (int i = 0; i < count; i++)
            {
                string identifier = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d53");
                string personalTitle = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d54");
                string firstname = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d55");
                string middlename = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d56");
                string lastname = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d57");
                string country = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d59");
                string state = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d510");
                string zip = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d511");
                string city = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d512");
                string address = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d513");
                string company = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d514");
                string accountNumber = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d515");
                string taxNumber = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d516");
                string registerNumber = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d517");
                string phone1 = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d527");
                string phone2 = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d529");
                string mobile1 = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d531");
                string mobile2 = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d533");
                string fax = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d535");
                string web = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d537");
                string email1 = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d539");
                string email2 = aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d541");
                string note = aux.ControlGetText(WinTitle, "", "WindowsForms10.RichEdit20W.app.0.2c908d51");

                list.Add(new ContactData() 
                { 
                    Id = identifier,
                    Title = personalTitle,
                    Firstname = firstname,
                    Middlename = middlename,
                    Lastname = lastname,
                    Country = country,
                    State = state,
                    Zip = zip,
                    City = city,
                    Address = address,
                    CompanyName = company,
                    AccountNumber = accountNumber,
                    TaxNumber = taxNumber,
                    RegisterNumber = registerNumber,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    Mobile1 = mobile1,
                    Mobile2 = mobile2,
                    Fax = fax,
                    Web = web,
                    Email1 = email1,
                    Email2 = email2,
                    Note = note
                });
                aux.Send("{DOWN}");
            }
            for (int i = 0; i < count; i++)
            {
                aux.Send("{UP}");
            }
            return list;
        }

        internal void ModifyContact(ContactData modifiedContact, int index)
        {
            if (index == 0)
            {
                aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d56");
                FillForm(modifiedContact);
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.BUTTON.app.0.2c908d58");
                WindowWait(WinTitle);
                aux.ControlClick(WinTitle, "", "WindowsForms10.Window.8.app.0.2c908d510");
                int count = GetContactList().Count;
                for (int i = 0; i < count; i++)
                {
                    aux.Send("{UP}");
                }
            }
            else
            {
                for (int i = 0; i <= index - 1; i++)
                {
                    aux.Send("{DOWN}");
                }
                aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d56");
                FillForm(modifiedContact);
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            }
        }

        public List<string> GetIdentifiers()
        {
            WindowWait(WinTitle);
            List<string> list = new List<string>();
            int count = Int32.Parse(aux.ControlGetText(WinTitle, "", "WindowsForms10.STATIC.app.0.2c908d55").Split('/')[1]);
            for (int i = 0; i < count; i++)
            {
                string item = aux.ControlGetText(WinTitle, "", "WindowsForms10.EDIT.app.0.2c908d53");
                list.Add(item);
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
                WindowWait(WinTitle);
            }
            else
            {
                for (int i = 0; i <= index - 1; i++)
                {
                    aux.Send("{DOWN}");
                }
                aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d59");
                aux.Send("{LEFT}{ENTER}");
                WindowWait(WinTitle);
            }
        }

        public void CreateNewContact(ContactData newContact)
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            FillForm(newContact);
            aux.ControlClick(WinContactEditor, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            WindowWait(WinTitle);
            aux.ControlClick(WinTitle, "", "WindowsForms10.Window.8.app.0.2c908d510");
            int count = GetContactList().Count;
            for (int i = 0; i < count; i++)
            {
                aux.Send("{UP}");
            }
        }

        private void FillForm(ContactData contact)
        {
            WindowWait(WinContactEditor);

            // first name
            if (contact.Firstname != null)
            {
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d516");
                aux.Send("^a"); // highlight row
                aux.Send(contact.Firstname);
            }

            // identifier
            if (contact.Id != null)
            {
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d517");
                aux.Send("^a");
                aux.Send(contact.Id);
            }

            // personal title
            if (contact.Title != null)
            {
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d511");
                aux.Send("^a");
                aux.Send(contact.Title);
            }

            //// middle name
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d515");
            //aux.Send(contact.Middlename);

            //// last name
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d513");
            //aux.Send(contact.Lastname);

            //// country
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d59");
            //aux.Send(contact.Country);

            //// city
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d56");
            //aux.Send(contact.City);

            //// state
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d58");
            //aux.Send(contact.State);

            //// zip
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d57");
            //aux.Send(contact.Zip);

            //// address
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d54");
            //aux.Send(contact.Address);

            //// phone (1)
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d520");
            //aux.Send(contact.Phone1);

            //// phone (2)
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d523");
            //aux.Send(contact.Phone2);

            //// fax
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d521");
            //aux.Send(contact.Fax);

            //// mobile (1)
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d519");
            //aux.Send(contact.Mobile1);

            //// mobile (2)
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d514");
            //aux.Send(contact.Mobile2);

            //// web
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d522");
            //aux.Send(contact.Web);

            //// email (1)
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d518");
            //aux.Send(contact.Email1);

            //// email (2)
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d512");
            //aux.Send(contact.Email2);

            //// note 
            //aux.ControlClick(WinContactEditor, "", "WindowsForms10.RichEdit20W.app.0.2c908d51");
            //aux.Send(contact.Note);

            if (contact.CompanyName != null)
            {
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.BUTTON.app.0.2c908d51");

                // company name
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d55");
                aux.Send(contact.CompanyName);

                // account number
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d53");
                aux.Send(contact.AccountNumber);

                // tax number
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d52");
                aux.Send(contact.TaxNumber);

                // register number
                aux.ControlClick(WinContactEditor, "", "WindowsForms10.EDIT.app.0.2c908d51");
                aux.Send(contact.RegisterNumber);
            }
        }
    }
}
