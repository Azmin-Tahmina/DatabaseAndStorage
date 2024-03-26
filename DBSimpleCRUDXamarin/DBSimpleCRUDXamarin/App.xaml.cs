using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBSimpleCRUDXamarin
{


    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        static DatabaseHelper databaseHelper;
        public static DatabaseHelper database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ItemDatabase.db3");
                    databaseHelper = new DatabaseHelper(dbPath);
                }
                return databaseHelper;
            }
        }
        // we can pass the tablenames to make it generic
        
        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
