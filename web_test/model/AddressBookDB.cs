using LinqToDB;

namespace WebAddressbookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook")
        { }
        public DataContext db = new DataContext("MySql.Data.MySqlClient", "Server=localhost;Port=3306;Database=addressbook;Uid=root;Pwd=;charset=utf8;Allow Zero Datetime=true");
        public ITable<GroupData> Groups 
        { 
            get
            {
                return db.GetTable<GroupData>();
            }
        }

        public ITable<ContactData> Contacts
        {
            get
            {
                return db.GetTable<ContactData>();
            }
        }

        public ITable<GroupContactRelation> RelationGroupContact
        {
            get
            {
                return db.GetTable<GroupContactRelation>();
            }
        }

    }
}
