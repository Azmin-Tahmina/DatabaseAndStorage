using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSimpleCRUDXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsListPage : ContentPage
    {

        DatabaseHelper db = new DatabaseHelper();
        public ItemsListPage()
        {
            InitializeComponent();
            var items = db.GetItems();
            foreach (var item in items)
            {
                Debug.WriteLine($"Item Name: {item.Name}");
            }
            //itemsListView.ItemsSource= db.GetItems();
            // Load items when the page appears

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            itemsListView.ItemsSource = db.GetItems();
        }

        //protected void LoadItems()
        //{
        //    itemsListView.ItemsSource = App.database.GetItems();
        //}

        //private async void OnAddClicked(object sender, EventArgs e)
        //{
        //    LoadItems(); // Refresh the list
        //}

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            //Refresh the list
            //LoadItems();
            //add a navigation page
        }
    }
}