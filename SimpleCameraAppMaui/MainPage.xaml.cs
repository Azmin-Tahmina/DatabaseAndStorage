namespace SimpleCameraAppMaui
{
    public partial class MainPage : ContentPage
    {
        
        static string? photoPath;
       
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
        // For windows , no set up required 
        // For android, follow necessary steps
        private async Task DoCapturePhoto()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                await LoadPhotoAsync(photo);
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
                return;
            }

            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);
            }

            SampleImage.Source = newFile;
            

        }
    }

}
