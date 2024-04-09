using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace c1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //InitializeComponent();
            StoreCameraMediaOptions options = new StoreCameraMediaOptions();
            CrossMedia.Current.TakePhotoAsync(options);
        }
    }
}
