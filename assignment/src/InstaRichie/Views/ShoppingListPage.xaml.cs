// **************************************************************************
//Start Finance - An to manage your personal finances.

//Start Finance is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//Start Finance is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with Start Finance.If not, see<http://www.gnu.org/licenses/>.
// ***************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite;
using StartFinance.Models;
using Windows.UI.Popups;
using SQLite.Net;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShoppingListPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Findata.sqlite");

        public ShoppingListPage()
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
            conn.CreateTable<ShoppingList>();
            var query1 = conn.Table<ShoppingList>();
            ShoppingListView.ItemsSource = query1.ToList();
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_PurchaseName.Text.ToString() == "")
                {
                    MessageDialog dialog = new MessageDialog("No value entered", "Did you really need a shopping list?");
                    await dialog.ShowAsync();
                }
                else
                {
                    double TempMoney = Convert.ToDouble(MoneyIn.Text);
                    conn.CreateTable<ShoppingList>();
                    conn.Insert(new ShoppingList
                    {
                        ProductName = _PurchaseName.Text.ToString(),
                        Money = TempMoney
                    });
                    // Creating table
                    Results();
                }
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageDialog dialog = new MessageDialog("You forgot to enter the Amount or entered an invalid Amount", "Oops..!");
                    await dialog.ShowAsync();
                }
                else if (ex is SQLiteException)
                {
                    MessageDialog dialog = new MessageDialog("Product name already exist, Try Different Name", "Do you really need that much?");
                    await dialog.ShowAsync();
                }
                else
                {
                    /// no idea
                }
            }
        }

        private async void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int AccSelection = ((ShoppingList)ShoppingListView.SelectedItem).ID;
                if (AccSelection < 0)
                {
                    MessageDialog dialog = new MessageDialog("Oops..!", "Please select an item.");
                    await dialog.ShowAsync();
                }
                else
                {               
                    try
                    {
                        if (_PurchaseName.Text.ToString() == "")
                        {
                            MessageDialog dialog = new MessageDialog("No value entered", "Did you really need a shopping list?");
                            await dialog.ShowAsync();
                        }
                        else
                        {
                            double TempMoney = Convert.ToDouble(MoneyIn.Text);
                            conn.Query<ShoppingList>("UPDATE ShoppingList SET ProductName = '" + _PurchaseName.Text.ToString() + "', Money = '" + TempMoney + "' WHERE ID = " + AccSelection);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is FormatException)
                        {
                            MessageDialog dialog = new MessageDialog("You forgot to enter the Amount or entered an invalid Amount", "Oops..!");
                            await dialog.ShowAsync();
                        }
                        else if (ex is SQLiteException)
                        {
                            MessageDialog dialog = new MessageDialog("Product name already exist, Try Different Name", "Do you really need that much?");
                            await dialog.ShowAsync();
                        }
                        else
                        {
                            /// no idea
                        }
                    }
                    var query1 = conn.Table<ShoppingList>();
                    ShoppingListView.ItemsSource = query1.ToList();
                }
            }
            catch (NullReferenceException)
            {
                MessageDialog dialog = new MessageDialog("Oops..!", "Please select an item.");
                await dialog.ShowAsync();
            }
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string AccSelection = ((ShoppingList)ShoppingListView.SelectedItem).ProductName;
                if (AccSelection == "")
                {
                    MessageDialog dialog = new MessageDialog("Oops..!", "Please select an item.");
                    await dialog.ShowAsync();
                }
                else
                {
                    conn.CreateTable<ShoppingList>();
                    var query1 = conn.Table<ShoppingList>();
                    var query3 = conn.Query<ShoppingList>("DELETE FROM ShoppingList WHERE ProductName ='" + AccSelection + "'");
                    ShoppingListView.ItemsSource = query1.ToList();
                }
            }
            catch (NullReferenceException)
            {
                MessageDialog dialog = new MessageDialog("Oops..!", "Please select an item.");
                await dialog.ShowAsync();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Results();
        }        
    }
}
