using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class ContactData : IComparable<ContactData>//, IEquatable<ContactData>
    {
        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Mobile1 { get; set; }

        public string Mobile2 { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Fax { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Web { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Group { get; set; }

        public string TaxNumber { get; set; }

        public string AccountNumber { get; set; }

        public string RegisterNumber { get; set; }

        public string Id { get; set; }

        public string Note { get; set; }

        public override string ToString()
        {
            return $"Identifier={Id} Firstname={Firstname}";
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.Firstname.CompareTo(other.Firstname);
        }

        public override bool Equals(object obj)
        {
            ContactData other = obj as ContactData;
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, null))
            {
                return true;
            }
            return this.Id.Equals(other.Id);
        }
    }
}
