using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSimpleCRUDXamarin
{
    public class ItemTableStructure
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // we need to apply validation

    }
}
