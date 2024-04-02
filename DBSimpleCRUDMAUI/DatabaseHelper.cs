using DBSimpleCRUDMAUI;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSimpleCRUDMAUI
{
    public class DatabaseHelper
    {
        public SQLiteConnection database;

        public DatabaseHelper()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "studentDB1.db3");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Students>();
            database.CreateTable<CourseDetails>();
            database.CreateTable<CourseStudentMapping>();
        }

        // CRUD Operations
        public List<T> GetItems<T>() where T : new()
        {
            List<T> items = database.Table<T>().ToList();

            return items;
        }

        public int SaveItem<T>(T item) where T : new()
        {
            
            var prop = item.GetType().GetProperty("id");

            if (prop != null)
            {
                var value = prop.GetValue(item);
                if (value != null && (int)value != 0)
                {
                    
                    return database.Update(item);
                }
            }
            
            return database.Insert(item); 
        }


        public T GetItem<T>(int id) where T : new()
        {
            var propInfo = typeof(T).GetProperty("id");

            if (propInfo != null)
            {
                return database.Table<T>().FirstOrDefault(item => (int) propInfo.GetValue(item) == id);
            }
            throw new InvalidOperationException("Entity type does not have an ID property.");
        }

        public bool UpdateItem<T>(T item) where T : new()
        {
            try
            {
                var result = database.Update(item);
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteItem<T>(int id) where T : new()
        {
            try
            {
                var item = GetItem<T>(id);
                if (item != null)
                {
                    var result = database.Delete(item);
                    return result > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}



