using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBFuelExample
{
    public partial class App : Application
    {

        static FuelDatabaseHelper database;
        public static FuelDatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FuelSQLite.db3");
                    database = new FuelDatabaseHelper(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            database = Database;
            EntryCell eLitres = new EntryCell { Label = "Litres:" };
            EntryCell eDate = new EntryCell { Label = "Date:" };
            EntryCell eCost = new EntryCell { Label = "Cost:" };
            EntryCell eID = new EntryCell { Label = "ID:" };

            var btnSearch = new Button { Text = "Read" };
            btnSearch.Clicked += (sender, e) =>
            {
                FuelPurchase purchase = database.GetItem(Convert.ToInt32(eID.Text));
                eID.Text = purchase.ID.ToString();
                eDate.Text = purchase.date.ToString();
                eLitres.Text = purchase.litres.ToString();
                eCost.Text = purchase.cost.ToString();

            };

            var btnNew = new Button { Text = "New" };
            btnNew.Clicked += (sender, e) => {
                eID.Text = "0"; eCost.Text = "";
                eDate.Text = ""; eLitres.Text = "";
            };
            var btnDelete = new Button { Text = "Delete" };
            btnDelete.Clicked += (sender, e) =>
            {
                database.DeleteItemAsync(database.GetItem(Convert.ToInt32(eID.Text)));
                // add code to clear text boxes too maybe
            };
            var btnSave = new Button { Text = "Save" };
            btnSave.Clicked += (sender, e) =>
            {
                FuelPurchase purchase = new FuelPurchase()
                {
                    ID = Convert.ToInt32(eID.Text),
                    cost = Convert.ToDouble(eCost.Text),
                    litres = Convert.ToDouble(eLitres.Text),
                    date = Convert.ToDateTime(eDate.Text)
                };
                database.SaveItem(purchase);
            };

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Spacing = 25, // this will alter distance between elements
                    Padding = 75, // this will alter distance from side of frame
                    Children =
                    { new TableView{Intent = TableIntent.Form, Root =
                            new TableRoot{
                      new TableSection("Fuel Purchase"){eID, eDate, eLitres, eCost } }},
                        new StackLayout{Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.Center,
                                Children = {btnNew, btnDelete, btnSave, btnSearch } }
                    },
                },
            };

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
