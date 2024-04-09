using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SimpleCameraApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            TakePhoto.Clicked += TakePhoto_Clicked;
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if (photo != null)
            {
                Photo.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }
        }
    }
}
