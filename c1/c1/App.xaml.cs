using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c1
{
    public partial class App : Application
    {
        public App()
        {
            //InitializeComponent();

            //MainPage = new MainPage();
            StackLayout layout = new StackLayout();
            Label lblPath = new Label { Text = "Path" };
            Image photoImage = new Image();
            Button btnCam = new Button { Text = "Take Photo" };
            btnCam.Clicked += async (sender, e) =>
            {
                string filename = "img";
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { Name = filename });

                if (photo != null)
                {
                    lblPath.Text = photo.Path;
                    photoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
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
