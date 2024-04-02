using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSimpleCRUDMAUI
{
    public class CourseDetails
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string courseName { get; set; }
        public string courseDescription{ get; set; }

        
    }
}
