using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFuelSimpleMAUI
{
    public class FuelRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }
        public double Litres { get; set; }
    }
}
