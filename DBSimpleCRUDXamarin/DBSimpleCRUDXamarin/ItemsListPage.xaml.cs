using System;
using System.Collections.Generic;
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
        public ItemsListPage()
        {
            InitializeComponent();
            // Load items when the page appears
            this.Appearing += (sender, e) => LoadItems();
        }

        protected void LoadItems()
        {
            itemsListView.ItemsSource = App.database.GetItems();
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            LoadItems(); // Refresh the list
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}