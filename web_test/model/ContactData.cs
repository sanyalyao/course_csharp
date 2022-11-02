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
        private string howOld;
        private string howLong;

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
        public string HowOld
        {
            get
            {
                return $"{DateTime.Now.Year - Int32.Parse(Byear)}";
            }
            set
            {
                howOld = value;
            }
        }

        public string HowLong
        {
            get
            {
                return $"{DateTime.Now.Year - Int32.Parse(Ayear)}";
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
                    return $"{FirstName} "
                        + (MiddleName == "" ? "" : $"{MiddleName} ")
                        + LastName
                        + ("\r\n" + Nickname == "\r\n" ? "" : "\r\n" + Nickname)
                        + ("\r\n" + Title == "\r\n" ? "" : "\r\n" + Title)
                        + ("\r\n" + Company == "\r\n" ? "" : "\r\n" + Company)
                        + ("\r\n" + Address == "\r\n" ? "" : "\r\n" + Address)
                        + ($"\r\n\r\nH: {HomeTelephone}" == "\r\n\r\nH: " ? "" : $"\r\n\r\nH: {HomeTelephone}")
                        + StructurePhone($"\r\nM: {Mobile}" == "\r\nM: " ? "" : $"\r\nM: {Mobile}")
                        + StructurePhone($"\r\nW: {WorkTelephone}" == "\r\nW: " ? "" : $"\r\nW: {WorkTelephone}")
                        + StructurePhone($"\r\nF: {Fax}" == "\r\nF: " ? "" : $"\r\nF: {Fax}")
                        + ("\r\n\r\n" + AllEmails == "\r\n\r\n" ? "" : "\r\n\r\n" + AllEmails)
                        + ($"\r\nHomepage:\r\n{Homepage}" == "\r\nHomepage:\r\n" ? "" : $"\r\nHomepage:\r\n{Homepage}")
                        + GetBirthday()
                        + GetAnniversary()
                        + ("\r\n\r\n" + SecondaryAddress == "\r\n\r\n" ? "" : "\r\n\r\n" + SecondaryAddress)
                        + ($"\r\n\r\nP: {SecondaryHomePhone}" == "\r\n\r\nP: " ? "" : $"\r\n\r\nP: {SecondaryHomePhone}")
                        + ("\r\n\r\n" + SecondaryNotes == "\r\n\r\n" ? "" : "\r\n\r\n" + SecondaryNotes);
                }
            }
            set
            {
                allInformation = value;
            }
        }

        public string StructurePhone(string phone)
        {
            if (HomeTelephone != "")
                return phone;
            return "\r\n" + phone == "\r\n" ? "" : "\r\n" + phone;
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
