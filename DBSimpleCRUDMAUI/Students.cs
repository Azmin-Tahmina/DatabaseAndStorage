using SQLite;

namespace DBSimpleCRUDMAUI
{
    public class Students
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public int age { get; set; }


        //public int age
        //{
        //    get
        //    {
        //        return age;
        //    }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("Age cannot be negative");
        //        }
        //        age = value;
        //    }
        //}
        public bool active { get; set; }
        public int courseCount { get; set; }

        public string fullName
        {
            get
            {
                return "Name:" + " " + firstName + " " + lastName;
            }
        }
    }
}
