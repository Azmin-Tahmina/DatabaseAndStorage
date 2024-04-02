using System.Collections.ObjectModel;

namespace DBSimpleCRUDMAUI.NavigationPages;

public partial class add : ContentPage
{
    DatabaseHelper dhelper = new DatabaseHelper();

    public add()
    {
        InitializeComponent();
    } 

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        Students newStudent = new Students
        {
            firstName = FirstNameEntry.Text,
            lastName = LastNameEntry.Text,
            age = Convert.ToInt32(AgeEntry.Text),
            active = ActiveSwitch.IsToggled.Equals(true),
            //courseCount = Convert.ToInt32(CourseCountEntry.Text)
        };

        dhelper.SaveItem<Students>(newStudent);
        await Shell.Current.GoToAsync("home");

    }

    // Some edit functions need to be added



}
