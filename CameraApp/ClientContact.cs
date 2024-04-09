using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraApp
{
    public class ClientContact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String FullName { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Photo { get; set; }
    }
}
