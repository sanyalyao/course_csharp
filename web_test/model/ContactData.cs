using System;
using System.Text;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInformation;
        private int howOld;
        private int howLong;

        public ContactData()
        {
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, null))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"first name = {FirstName}; last name = {LastName}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.ToLower().CompareTo(other.LastName.ToLower()) == 0)
            {
                return FirstName.ToLower().CompareTo(other.FirstName.ToLower());
            }
            return LastName.ToLower().CompareTo(other.LastName.ToLower());
        }

        public string Bday {get;set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomeTelephone { get; set; }

        public string Mobile { get; set; }

        public string WorkTelephone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Group { get; set; }

        public string SecondaryAddress { get; set; }

        public string SecondaryHomePhone { get; set; }

        public string SecondaryNotes { get; set; }

        public string Id { get; set; }

        public int HowOld
        {
            get
            {
                return Byear == null ? 0 : DateTime.Now.Year - Int32.Parse(Byear);
            }
            set
            {
                howOld = value;
            }
        }

        public int HowLong
        {
            get
            {
                return Ayear == null ? 0 : DateTime.Now.Year - Int32.Parse(Ayear);
            }
            set
            {
                howLong = value;
            }
        }

        public string AllInformation
        {
            get
            {
                if (allInformation != null)
                {
                    return allInformation;
                }
                else
                {
                    return (StructureName(FirstName)
                        + StructureName(MiddleName)
                        + StructureName(LastName)
                        + StructureFirstInfo(Nickname)
                        + StructureFirstInfo(Title)
                        + StructureFirstInfo(Company)
                        + StructureFirstInfo(Address)
                        + GetPhone()
                        + (AllEmails == "" ? "" : "\r\n\r\n" + AllEmails)
                        + GetHomepage()
                        + GetBirthday()
                        + GetAnniversary()
                        + GetSecondaryInformation()).Trim();
                };
            }
            set
            {
                allInformation = value;
            }
        }
        public string StructureName(string name)
        {
            return name == "" ? "" : $" {name}";
        }

        public string StructureFirstInfo(string info)
        {
            return (info == "" ? "" : "\r\n" + info);
        }

        public string GetPhone()
        {
            if (HomeTelephone == "" && Mobile == "" && WorkTelephone == "" && Fax == "")
                return "";
            return "\r\n" + (HomeTelephone == "" ? "" : $"\r\nH: {HomeTelephone}") + (Mobile == "" ? "" : $"\r\nM: {Mobile}") + (WorkTelephone == "" ? "" : $"\r\nW: {WorkTelephone}") + (Fax == "" ? "" : $"\r\nF: {Fax}");
        }

        public string GetHomepage()
        {
            if (Homepage == "")
                return Homepage;
            if (AllEmails == null)
            {
                return $"\r\n\r\nHomepage:\r\n{Homepage}";
            }
            return $"\r\nHomepage:\r\n{Homepage}";
        }

        public string GetBirthday()
        {
            StringBuilder result = new StringBuilder();
            if (Bday == "" && Bmonth == "" && Byear == "")
                return "";
            if (Bday != "")
                result.Append($" {Bday}.");
            if (Bmonth != "")
                result.Append($" {Bmonth}");
            if (Byear != "")
                result.Append($" {Byear} ({HowOld})");
            return "\r\n\r\n" + "Birthday" + result;
        }

        public string GetAnniversary()
        {
            StringBuilder result = new StringBuilder();
            if (Aday == "" && Amonth == "" && Ayear == "")
                return "";
            if (Aday != "")
                result.Append($" {Aday}.");
            if (Amonth != "")
                result.Append($" {Amonth}");
            if (Ayear != "")
                result.Append($" {Ayear} ({HowLong})");
            if (GetBirthday() != "")
                return "\r\n" + "Anniversary" + result;
            return "\r\n\r\n" + "Anniversary" + result;
        }

        public string GetSecondaryInformation()
        {
            if (GetBirthday() == "" && GetAnniversary() == "" && SecondaryAddress != "") 
            {
                return "\r\n" + (SecondaryAddress == "" ? "" : "\r\n\r\n" + SecondaryAddress)
                    + (SecondaryHomePhone == "" ? "" : $"\r\n\r\nP: {SecondaryHomePhone}")
                    + (SecondaryNotes == "" ? "" : "\r\n\r\n" + SecondaryNotes);
            }
            if (GetBirthday() == "" && GetAnniversary() == "" && SecondaryAddress == "")
            {
                return "\r\n\r\n" + (SecondaryHomePhone == "" ? "" : $"\r\n\r\nP: {SecondaryHomePhone}")
                    + (SecondaryNotes == "" ? "" : "\r\n\r\n" + SecondaryNotes);

            }
            if (SecondaryAddress == "")
            {
                return "\r\n" + (SecondaryHomePhone == "" ? "" : $"\r\n\r\nP: {SecondaryHomePhone}")
                    + (SecondaryNotes == "" ? "" : "\r\n\r\n" + SecondaryNotes);
            }
            return (SecondaryAddress == "" ? "" : "\r\n\r\n" + SecondaryAddress)
                        + (SecondaryHomePhone == "" ? "" : $"\r\n\r\nP: {SecondaryHomePhone}")
                        + (SecondaryNotes == "" ? "" : "\r\n\r\n" + SecondaryNotes);
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string CleanUpEmail(string email)
        {
            if (email == null || allEmails == "" || email == "")
            {
                return "";
            }
            return email + "\r\n";

        }

        public string AllPhones 
        {
            get 
            { 
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomeTelephone) + CleanUp(Mobile) + CleanUp(WorkTelephone) + CleanUp(SecondaryHomePhone)).Trim();
                }
            }
            set 
            {
                allPhones = value;
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || allPhones == "" || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, @"[ ()-]", "") + "\r\n";
        }
    }
}
