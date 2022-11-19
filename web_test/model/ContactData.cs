using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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


        [Column(Name = "firstName")]
        public string FirstName { get; set; }

        [Column(Name = "middleName")]
        public string MiddleName { get; set; }

        [Column(Name = "lastName")]
        public string LastName { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomeTelephone { get; set; }

        [Column(Name = "mobile")]
        public string Mobile { get; set; }

        [Column(Name = "work")]
        public string WorkTelephone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        public string Group { get; set; }

        [Column(Name = "address2")]
        public string SecondaryAddress { get; set; }

        [Column(Name = "phone2")]
        public string SecondaryHomePhone { get; set; }

        [Column(Name = "notes")]
        public string SecondaryNotes { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from contactDB in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select contactDB).ToList(); 
            }
        }
        public List<GroupData> GetGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from groupDB in db.Groups
                        from relation in db.RelationGroupContact.Where(gr => gr.ContactId == Id && gr.GroupId == groupDB.Id && groupDB.Deprecated == "0000-00-00 00:00:00")
                        select groupDB).Distinct().ToList();
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
