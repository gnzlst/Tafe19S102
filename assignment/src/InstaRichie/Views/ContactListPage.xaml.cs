using StartFinance.Models;
using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Services.NavigationService;
using Template10.Services.SerializationService;
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
    public sealed partial class ContactListPage : Page
    {
        ContactPageViewModel viewModel;

        public ContactListPage()
        {
            this.InitializeComponent();
            viewModel = new ContactPageViewModel();
            if (!viewModel.IsDataLoaded) { viewModel.LoadData(); }
            this.Loaded += new RoutedEventHandler(ContactListPage_Loaded);
            ContactList.ItemsSource = viewModel.Contacts;

        }

        

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = ContactList.SelectedItem as Contact;
            MessageDialog md;

            if (viewModel.DeleteContact(contact.ContactId))
            {
                md = new MessageDialog("Contact Successfully Deleted!");
                viewModel = new ContactPageViewModel();
                if (!viewModel.IsDataLoaded) { viewModel.LoadData(); }
                this.Loaded += new RoutedEventHandler(ContactListPage_Loaded);
                ContactList.ItemsSource = viewModel.Contacts;
            }
            else
            {
                md = new MessageDialog("You should never see this message. If you do, somehow you tried to delete something that doesn't exist. How I wonder?");
            }

            await md.ShowAsync();
        }

        private void ContactListPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var contact = this.ContactList.SelectedItem as Contact;
            if (contact != null)
            {
                int id = contact.ContactId;
                var NavService = NavigationService.GetForFrame(this.Frame);
                NavService.Navigate(typeof(ContactPage), id);


                //string str = SerializationService.Json.Serialize(id);
                //Frame.Navigate(typeof(ContactPage), str);

                //Frame.Navigate(typeof(ContactPage), id);
            }
            else
            {
                await new MessageDialog("You didn't select any contact to update!").ShowAsync();
                return;
            }

        }
    }
}
