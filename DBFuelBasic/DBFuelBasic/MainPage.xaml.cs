using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DBFuelBasic
{
    public partial class MainPage : ContentPage
    {
        DatabaseService databaseService;

        public MainPage()
        {
            InitializeComponent();
            databaseService = new DatabaseService();

            // Load records on page initialization
            LoadFuelRecords();
        }

        private void OnAddRecordClicked(object sender, EventArgs e)
        {
            // Add a new record with random data for demonstration
            Random random = new Random();
            databaseService.InsertFuelRecord(new FuelRecord
            {
                Cost = random.NextDouble() * 100, // Random cost between 0-100
                Date = DateTime.Now,
                Litres = random.NextDouble() * 50 // Random litres between 0-50
            });

            // Reload records to update the ListView
            LoadFuelRecords();
        }

        private void LoadFuelRecords()
        {
            var records = databaseService.GetAllFuelRecords();
            fuelRecordsListView.ItemsSource = records;
        }
    }
}
