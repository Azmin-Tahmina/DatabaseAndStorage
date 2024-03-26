using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSimpleCRUDXamarin
{
    public class DatabaseHelper
    {
        public SQLiteConnection database;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<ItemTableStructure>();
            if (database.Table<ItemTableStructure>().Count() == 0) //if no records  make one
            {
                // this will get the next key
                ItemTableStructure newItem = new ItemTableStructure();
                newItem.Name = "Test Name";
                newItem.Description = "Test Description";
            }
        }

        // CRUD Operations
        public void AddItem(ItemTableStructure item)
        {
            database.Insert(item);
        }

        public IEnumerable<ItemTableStructure> GetItems()
        {
            return database.Table<ItemTableStructure>().ToList();
        }

        public ItemTableStructure GetItem(int id)
        {
            return database.Table<ItemTableStructure>().FirstOrDefault(item => item.ID == id);
        }

        public void UpdateItem(ItemTableStructure item)
        {
            database.Update(item);
        }

        public void DeleteItem(int id)
        {
            var item = GetItem(id);
            if (item != null)
            {
                database.Delete(item);
            }
        }

    }
}



