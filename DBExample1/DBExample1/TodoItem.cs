using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBExample1
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }
}
