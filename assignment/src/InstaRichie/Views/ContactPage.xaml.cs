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

        private ContactPageViewModel viewModel;

        public ContactPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            Contact contact;
            int id;
            
            if(e.Parameter != null)
            {
                //id = (int)e.Parameter;
                id = Template10.Services.SerializationService.SerializationService.Json.Deserialize<int>(e.Parameter?.ToString());
                viewModel = new ContactPageViewModel(id);

                contact = viewModel.GetContactById(id);
                txtContactFirstName.Text = contact.ContactFirstName;
                txtContactLastName.Text = contact.ContactLastName;
                txtCompanyName.Text = contact.ContactCompanyName;
                txtMobilePhone.Text = contact.ContactMobilePhone;
            }
            base.OnNavigatedTo(e);
            viewModel = new ContactPageViewModel();
        }

        //private void Cancel_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(MainPage));
        //}

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            Models.Contact c = new Models.Contact();
            c.ContactFirstName = txtContactFirstName.Text;
            c.ContactLastName = txtContactLastName.Text;
            c.ContactCompanyName = txtCompanyName.Text;
            c.ContactMobilePhone = txtMobilePhone.Text;

            MessageDialog md;

            if (viewModel.AddNewContact(c))
            {
                viewModel.LoadData();
                md = new MessageDialog(c.ContactFirstName + " " + c.ContactLastName + " addedd to database");
                txtContactFirstName.Text = "";
                txtContactLastName.Text = "";
                txtCompanyName.Text = "";
                txtMobilePhone.Text = "";
            }
            else
            {
                md = new MessageDialog(c.ContactFirstName + " " + c.ContactLastName + " couldn't be added to database");
            }
            await md.ShowAsync();
        }
    }
}
