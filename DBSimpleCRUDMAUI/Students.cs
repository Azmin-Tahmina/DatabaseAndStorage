using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DBSimpleCRUDMAUI
{
    public class Students 
        //: INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged([CallerMemberName] string property = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(property));
        //    }
        //}

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public int age { get; set; }

        //private bool _active;
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

        //public bool active
        //{
        //    get { return _active; }
        //    set
        //    {
        //        if (value != _active)
        //        {
        //            _active = value;
        //            OnPropertyChanged();
        //        }
        //    }

        //}
        public int courseCount { get; set; }

        public string fullName
        {
            get
            {
                return "Name:" + " " + firstName + " " + lastName;
            }
        }

        public string formattedId
        {
            get
            {
                return "ID:" + " " + id;
            }
        }
    }
}
