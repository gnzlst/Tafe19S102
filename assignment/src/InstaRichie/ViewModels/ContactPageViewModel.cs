using SQLite.Net;
using StartFinance.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace StartFinance.ViewModels
{
    class ContactPageViewModel : INotifyPropertyChanged
    {
        private Contact contact;
        private IContactRepository Db { get; }
        public ObservableCollection<Contact> Contacts { get; set; }

        SQLiteConnection conn; // adding an SQLite connection
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Findata.sqlite");


        public ContactPageViewModel()
        {
            Db = App.Data;

            // Initializing a database
            //conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

        }

        public Contact Contact
        {
            get { return contact; }
            set
            {
                if (contact != value)
                {
                    contact = value;
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Contacts = new ObservableCollection<Contact>(Db.GetContacts().ToList());
            this.IsDataLoaded = true;
        }

        internal bool AddNewContact(Contact newContact)
        {
            return Db.InsertContact(newContact);
        }

        //public DetailsViewModel(int productId)
        //{
        //    Db = App.Data;
        //    this.Product = Db.GetProductById(productId);
        //}

        public async void SaveEditedContact(Contact c)
        {
            //return Db.UpdateContact(c);
            MessageDialog md;
            if (Db.UpdateContact(c))
            {
                md = new MessageDialog("ContactPage Updated", "UPDATE");
            }
            else
            {
                md = new MessageDialog("ContactPage NOT Updated", "UPDATE");
            }
            await md.ShowAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
