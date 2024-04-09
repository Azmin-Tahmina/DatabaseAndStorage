using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraApp
{
    
    public class CLientDataHelper
    {
        public SQLiteConnection database;

        public CLientDataHelper()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clientDB.db3");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<ClientContact>();
        }

        public int SaveClient(ClientContact contact)
        {
            if (contact.ID == 0)
            {
                return database.Insert(contact);
            }
            else
            {
                return database.Update(contact);
            }
        }

        public List<ClientContact> GetClients()
        {
            return database.Table<ClientContact>().ToList<ClientContact>();
        }
    }


}
