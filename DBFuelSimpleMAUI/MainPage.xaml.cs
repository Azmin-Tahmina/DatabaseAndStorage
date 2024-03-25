namespace DBFuelSimpleMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            LoadFuelRecords();
        }

        private void OnAddRecordClicked(object sender, EventArgs e)
        {
            _databaseService.InsertFuelRecord(new FuelRecord { Cost = 60.5, Date = DateTime.Now, Litres = 22.5 });
            LoadFuelRecords(); // Refresh the list
        }

        private void LoadFuelRecords()
        {
            var records = _databaseService.GetAllFuelRecords();
            FuelRecordsView.ItemsSource = records;
        }
    }

}
