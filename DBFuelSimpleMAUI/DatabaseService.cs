using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DBFuelSimpleMAUI
{
    public class DatabaseService
    {
        private SQLiteConnection db;

        public DatabaseService()
        {
            // In MAUI, the local application data directory can be accessed like this:
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "FuelDB.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<FuelRecord>();
        }

        public void InsertFuelRecord(FuelRecord record)
        {
            db.Insert(record);
        }

        public List<FuelRecord> GetAllFuelRecords()
        {
            return db.Table<FuelRecord>().ToList();
        }
    }
}
