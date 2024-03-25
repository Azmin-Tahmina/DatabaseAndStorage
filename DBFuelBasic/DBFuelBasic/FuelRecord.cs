using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBFuelBasic
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
