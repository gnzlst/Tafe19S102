using SQLite.Net;
using StartFinance.Models;
using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactPage : Page
    {

        SQLiteConnection conn; // adding an SQLite connection
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Findata.sqlite");

        // private ContactPageViewModel viewModel;

        public ContactPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            /// Initializing a database
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            // Creating table
            Results();
        }

        public void Results()
        {
            conn.CreateTable<Contact>();
            var query1 = conn.Table<Contact>();
            ContactsListView.ItemsSource = query1.ToList();
        }

        private async void SaveContact_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md;
            Contact contact = new Models.Contact();


            if (txtContactFirstName.Text == "" || txtContactLastName.Text == "")
            {
                md = new MessageDialog("Insert First Name and Last Name Please!");
                await md.ShowAsync();
            }
            else
            {
                contact.ContactFirstName = txtContactFirstName.Text;
                contact.ContactLastName = txtContactLastName.Text;
                contact.ContactCompanyName = txtCompanyName.Text;
                contact.ContactMobilePhone = txtMobilePhone.Text;


                if (conn.Insert(contact) > 0)
                {
                    Results();
                    md = new MessageDialog("New Contact Successfully Added to the Database!", "INSERTION COMPLETE");
                }
                else
                {
                    md = new MessageDialog("Somewhere, something went wrong.", "SADNESS");
                }
            }

            txtContactFirstName.Text = "";
            txtContactLastName.Text = "";
            txtCompanyName.Text = "";
            txtMobilePhone.Text = "";

            await md.ShowAsync();
  
        }

        private async void EditContact_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md;

            Contact contact = (Contact)ContactsListView.SelectedItem;

            contact.ContactFirstName = txtContactFirstName.Text;
            contact.ContactLastName = txtContactLastName.Text;
            contact.ContactCompanyName = txtCompanyName.Text;
            contact.ContactMobilePhone = txtMobilePhone.Text;
                            

            if (conn.Update(contact) > 0)
            {
                Results();
                md = new MessageDialog("Something changed! It's not the same anymore");
            }
            else
            {
                md = new MessageDialog("Update failed! Check your code!");
            }

            await md.ShowAsync();
        }

        private async void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md;
            Contact contact = (Contact)ContactsListView.SelectedItem;
            try
            {
                conn.Delete(contact);
                md = new MessageDialog("Contact Deleted!");
            }
            catch(FormatException ex)
            {
                md = new MessageDialog("Nothing Selected!");
            }
            
            Results();
            await md.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Results();
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ContactsListView.SelectedItem != null)
            {
                Contact contact = (Contact)ContactsListView.SelectedItem;
                txtContactFirstName.Text = contact.ContactFirstName;
                txtContactLastName.Text = contact.ContactLastName;
                txtCompanyName.Text = contact.ContactCompanyName;
                txtMobilePhone.Text = contact.ContactMobilePhone;
            }                    
        }
    }
}

