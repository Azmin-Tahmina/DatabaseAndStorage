using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace CameraApp
{
    public partial class MainPage : ContentPage
    {
        static string? photoPath;

        CLientDataHelper dhelper = new CLientDataHelper();
        public ObservableCollection<ClientContact> clients { get; set; }
        public object PhotoPath { get; private set; }

        public MainPage()
        {
            InitializeComponent();
           
        }

        private async void OnPickPhotoClicked(object sender, EventArgs e)
        {
            await DoCapturePhoto();
        }

        // Sample code/function to capture photo
        //Source: https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?view=net-maui-8.0&tabs=android
        private async Task DoCapturePhoto()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                await LoadPhotoAsync(photo);

                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        // Sample code/function to capture photo
        //Source: https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?view=net-maui-8.0&tabs=android
        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }

            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }

            PhotoPath = newFile;
            Console.WriteLine(PhotoPath);

        }

        private void editClient(object sender, ItemTappedEventArgs e)
        {
            ClientListView.SelectedItem = null;
            Navigation.PushAsync(new ClientEdit(e.Item as ClientContact));
        }

        private void newClient(object sender, EventArgs e)
        {
           Navigation.PushAsync(new ClientEdit(null));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        private void LoadData()
        {
            List<ClientContact> cl = new List<ClientContact>(dhelper.GetClients());
            clients = new ObservableCollection<ClientContact>(cl);
            ClientListView.ItemsSource = clients;
        }

    }

}
