using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private Birthday birthday;
        private Anniversary anniversary;

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

        public string SecondaryHome { get; set; }

        public string SecondaryNotes { get; set; }

        public string Id { get; set; }
    }
}
