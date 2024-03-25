using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DBFuelBasic
{
    public class DatabaseService
    {
        private SQLiteConnection db;

        public DatabaseService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FuelDB.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<FuelRecord>();
        }

        public void InsertFuelRecord(FuelRecord record)
        {
            db.Insert(record);
        }

        public IEnumerable<FuelRecord> GetAllFuelRecords()
        {
            return db.Table<FuelRecord>().ToList();
        }
    }
}
