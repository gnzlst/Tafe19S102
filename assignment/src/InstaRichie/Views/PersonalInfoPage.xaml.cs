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
    public sealed partial class PersonalInfoPage : Page
    {

        SQLiteConnection conn; // adding an SQLite connection
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Findata.sqlite");

       

        public PersonalInfoPage()
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
            conn.CreateTable<PersonalInfo>();
            var query = conn.Table<PersonalInfo>();
            PersonalInfoListView.ItemsSource = query.ToList();
        }

        private async void SavePersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md;
            PersonalInfo personalInfo = new Models.PersonalInfo();


            if (txtPersonalFirstName.Text == "" || txtPersonalLastName.Text == "")
            {
                md = new MessageDialog("Insert First Name and Last Name Please!");
                await md.ShowAsync();
            }
            else
            {
                personalInfo.FirstName = txtPersonalFirstName.Text;
                personalInfo.LastName = txtPersonalLastName.Text;
                personalInfo.DOB = txtPersonalDOB.Text;
                personalInfo.Gender = txtPersonalGender.Text;
                personalInfo.EmailAddress = txtPersonalEmailAddress.Text;
                personalInfo.MobilePhone = txtPersonalMobilePhone.Text;


                if (conn.Insert(personalInfo) > 0)
                {
                    Results();
                    md = new MessageDialog("New Personal Info Successfully Added to the Database!", "INSERTION COMPLETE");
                }
                else
                {
                    md = new MessageDialog("Somewhere, something went wrong.", "SADNESS");
                }
            }

            txtPersonalFirstName.Text = "";
            txtPersonalLastName.Text = "";
            txtPersonalDOB.Text = "";
            txtPersonalGender.Text = "";
            txtPersonalEmailAddress.Text = "";
            txtPersonalMobilePhone.Text = "";

            await md.ShowAsync();
  
        }

        private async void EditPersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md;

            PersonalInfo personalInfo = (PersonalInfo)PersonalInfoListView.SelectedItem;

            personalInfo.FirstName = txtPersonalFirstName.Text;
            personalInfo.LastName = txtPersonalLastName.Text;
            personalInfo.DOB = txtPersonalDOB.Text;
            personalInfo.Gender = txtPersonalGender.Text;
            personalInfo.EmailAddress = txtPersonalEmailAddress.Text;
            personalInfo.MobilePhone = txtPersonalMobilePhone.Text;


            if (conn.Update(personalInfo) > 0)
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

        private async void DeletePersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md;
            PersonalInfo personalInfo = (PersonalInfo)PersonalInfoListView.SelectedItem;
            try
            {
                conn.Delete(personalInfo);
                md = new MessageDialog("Personal Info Deleted!");
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

        private void PersonalInfoListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(PersonalInfoListView.SelectedItem != null)
            {
                PersonalInfo personalInfo = (PersonalInfo)PersonalInfoListView.SelectedItem;
                personalInfo.FirstName = txtPersonalFirstName.Text;
                personalInfo.LastName = txtPersonalLastName.Text;
                personalInfo.DOB = txtPersonalDOB.Text;
                personalInfo.Gender = txtPersonalGender.Text;
                personalInfo.EmailAddress = txtPersonalEmailAddress.Text;
                personalInfo.MobilePhone = txtPersonalMobilePhone.Text;
            }
        }
    }
}

