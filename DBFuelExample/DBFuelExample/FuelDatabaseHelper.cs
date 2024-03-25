using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBFuelExample
{
    public class FuelDatabaseHelper
    {
        readonly SQLiteConnection database;
        public FuelDatabaseHelper(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            //database.DropTable<FuelPurchase>(); // can call this to drop if needed
            database.CreateTable<FuelPurchase>(); // won’t do anything if already exists
            if (database.Table<FuelPurchase>().Count() == 0) //if no records  make one
            {
                // this will get the next key
                FuelPurchase purchase = new FuelPurchase();
                purchase.cost = 15;
                purchase.date = new DateTime(2018, 1, 15);
                purchase.litres = 15;
                SaveItem(purchase);
            }

        }
        public List<FuelPurchase> GetItems()
        {
            return database.Table<FuelPurchase>().ToList<FuelPurchase>();
        }

        public List<FuelPurchase> GetItemsOverTen()
        {
            return database.Query<FuelPurchase>("SELECT * FROM [FuelPurchase] WHERE [litres] > 10");
        }

        public FuelPurchase GetItem(int id)
        {
            return database.Table<FuelPurchase>().Where(i => i.ID == id).FirstOrDefault();
        }

        public int SaveItem(FuelPurchase item)
        {
            if (item.ID != 0)
            {
                return database.Update(item);
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int DeleteItemAsync(FuelPurchase item)
        {
            if (item == null)
            {
                return -1;
            }
            return database.Delete(item);
        }

    }
}
