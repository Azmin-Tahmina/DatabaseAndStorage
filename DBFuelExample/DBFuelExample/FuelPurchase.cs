using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBFuelExample
{
    public class FuelPurchase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime date { get; set; }
        public double litres { get; set; }
        public double cost { get; set; }

    }
}
