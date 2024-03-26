using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DBExample1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TodoItem> Items { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<TodoItem>();
            ItemsListView.ItemsSource = Items;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var items = await App.Database.GetItemsAsync();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {

            var newItem = new TodoItem()
            { 
                Name = NewItemName.Text,
                Done = true
            };
            await App.Database.SaveItemAsync(newItem);
            Items.Add(newItem);
        }
        
    }
}

