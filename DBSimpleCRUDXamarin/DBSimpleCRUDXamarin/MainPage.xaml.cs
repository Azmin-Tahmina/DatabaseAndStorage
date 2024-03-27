using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DBSimpleCRUDXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnViewItemsClicked(object sender, EventArgs e)
        {
            // Navigate to the Items View Page
            await Navigation.PushAsync(new ItemsListPage());
        }

        public async void OnAddItemClicked(object sender, EventArgs e)
        {
            // Navigate to the Add Item Page
            await Navigation.PushAsync(new AddItemPage());
        }

       
    }
}
