
//using Android.Locations;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;
//using Windows.System;

namespace CameraApp;

public partial class ClientEdit : ContentPage
{

    CLientDataHelper dhelper = new CLientDataHelper();
    public ObservableCollection<ClientContact> clients { get; set; }
    public String PhotoPath = "";
    public ClientEdit(ClientContact cl)
    {
        InitializeComponent();
        if (cl == null)
        {
            button1.Text = "Add New Client";
            Title = "Add Client";
        }
        else
        {
            button1.Text = "Save CHanges";
            Title = "Edit Client";

        }

        button1.Clicked += (sender, e) =>
        {
            if (cl == null)
            {
                ClientContact newClient = new ClientContact
                {
                    FullName = name.Text,
                    Address = address.Text,
                    Phone = phone.Text,
                    Photo = PhotoPath
                };

                dhelper.SaveClient(newClient);
            }
            else
            {
                cl.FullName = name.Text;
                cl.Address = address.Text;
                cl.Phone = phone.Text;
                cl.Photo = PhotoPath;
                dhelper.SaveClient(cl);
            }
        };
    }

    private async void takePhoto(object sender, EventArgs e)
    {
        var photo = await MediaPicker.CapturePhotoAsync();
        if (photo != null)
        {
            //Creating name (optional)
            var photoName = "test";
            // Folder (optional)
            var testolder = "MauiPics";
            //I created custom folder, I need to use that images for list view
            var customFolderPath = Path.Combine(FileSystem.AppDataDirectory, testolder);

            if (!Directory.Exists(customFolderPath))
            {
                Directory.CreateDirectory(customFolderPath);
            }

            // var newFile = Path.Combine(FileSystem.CacheDirectory, photoName);

            var newFile = Path.Combine(customFolderPath, photoName);
            
            PhotoPath = newFile;

            using (var stream = await photo.OpenReadAsync())
            {
                using (var newStream = File.OpenWrite(newFile))
                {
                    await stream.CopyToAsync(newStream);
                }
            }

            img.Source = ImageSource.FromFile(newFile);

            //await DisplayAlert("Title", img.Source.ToString(), "Yes", "No");
        }

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        img.Source = PhotoPath;
    }

    
}