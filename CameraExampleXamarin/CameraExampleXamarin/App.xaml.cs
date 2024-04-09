using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CameraExampleXamarin
{
    public partial class App : Application
    {
        public App()
        {
            CrossMedia.Current.Initialize();
            //InitializeComponent();
            StackLayout layout = new StackLayout();
            Label lblPath = new Label { Text = "Path" };
            Image photoImage = new Image();
            Button btnCam = new Button { Text = "Take Photo" };

            btnCam.Clicked += async (sender, e) =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    lblPath.Text = "Camera not available.";
                    return;
                }

                // string filename = "img";
                // var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { Name = filename });

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    // Customizing the storage options
                    Name = $"{DateTime.Now:yyyyMMddHHmmss}.jpg",
                    Directory = "SamplePictures",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    PhotoSize = PhotoSize.Medium
                });

                //if (photo != null)
                //{
                //    lblPath.Text = photo.Path;
                //    photoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                //}

                if (file != null)
                {
                    lblPath.Text = file.AlbumPath ?? file.Path;
                    photoImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }


            };

            layout.Children.Add(lblPath);
            layout.Children.Add(photoImage);
            layout.Children.Add(btnCam);
            MainPage = new ContentPage { Content = layout };
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
