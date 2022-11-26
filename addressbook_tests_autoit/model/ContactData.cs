using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string Firstname { get; set; }
        public int CompareTo(ContactData other)
        {
            return this.Firstname.CompareTo(other.Firstname);
        }

        public bool Equals(ContactData other)
        {
            return this.Firstname.Equals(other.Firstname);
        }
    }
}
