using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DBExample1
{
    public class DatabaseHelper
    {
        readonly SQLiteAsyncConnection database;

        public DatabaseHelper(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
    }
}    

