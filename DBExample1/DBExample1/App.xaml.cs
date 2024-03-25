using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBExample1
{
    public partial class App : Application
    {
        public static DatabaseHelper Database { get; private set; }

        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
            Database = new DatabaseHelper(dbPath);

            MainPage = new MainPage();
        }


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
