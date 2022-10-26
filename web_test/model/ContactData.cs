using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string homeTelephone = "";
        private string mobile = "";
        private string workTelephone = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private Birthday birthday;
        private Anniversary anniversary;
        private string group = "";
        private string secondaryAddress = "";
        private string secondaryHome = "";
        private string secondaryNotes = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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

        public class Birthday
        {
            public int date { get; set; }
            public string month { get; set; }
            public int year { get; set; }
            public Birthday(int date, string month, int year)
            {
                this.date = date;
                this.month = month;
                this.year = year;
            }
        }

        public Birthday BirthdayDate
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public class Anniversary
        {
            public int date { get; set; }
            public string month { get; set; }
            public int year { get; set; }
            public Anniversary(int date, string month, int year)
            {
                this.date = date;
                this.month = month;
                this.year = year;
            }
        }

        public Anniversary AnniversaryDate
        {
            get { return anniversary; }
            set { anniversary = value; }
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string MiddleName
        {
            get { return middlename; }
            set { middlename = value; }
        }

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string HomeTelephone
        {
            get { return homeTelephone; }
            set { homeTelephone = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string WorkTelephone
        {
            get { return workTelephone; }
            set { workTelephone = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2= value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public string SecondaryAddress
        {
            get { return secondaryAddress; }
            set { secondaryAddress = value; }
        }

        public string SecondaryHome
        {
            get { return secondaryHome; }
            set { secondaryHome = value; }
        }

        public string SecondaryNotes
        {
            get { return secondaryNotes; }
            set { secondaryNotes = value; }
        }        
    }
}
