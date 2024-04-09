using Camera.MAUI;

namespace cameraMAUI
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

        private async void cameraView_CamerasLoaded(object sender, EventArgs e)
        {
            //cameraView.Camera = cameraView.Cameras.First();

            //MainThread.BeginInvokeOnMainThread(async () =>
            //{
            //    await cameraView.StopCameraAsync();
            //    await cameraView.StartCameraAsync();
            //});

            var photo = await cameraView.CaptureAsync();
            if(photo != null)
            {
                var photoPath = Path.Combine(FileSystem.AppDataDirectory);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            myImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
        }
    }

}
