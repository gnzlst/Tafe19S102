using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    class ContactRepository
    {
        string path;
        SQLiteConnection conn;

        public ContactRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Contact>();
        }
        public bool DeleteContact(int contactId)
        {
            Contact c = GetContactById(contactId);
            if (conn.Delete(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Contact GetContactById(int contactId)
        {
            var contacts = conn.Table<Contact>().ToList();
            return contacts.First(c => c.ContactId == contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return conn.Table<Contact>().ToList();
        }

        public bool InsertContact(Contact contact)
        {
            if (conn.Insert(contact) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            if (conn.Update(contact) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
