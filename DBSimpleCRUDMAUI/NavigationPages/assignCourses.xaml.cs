using System.Collections.ObjectModel;
using System.Data;

namespace DBSimpleCRUDMAUI.NavigationPages;

public partial class assignCourses : ContentPage
{
    DatabaseHelper dhelper = new DatabaseHelper();
    public ObservableCollection<CourseDetails> courses { get; set; }
    public assignCourses()
	{
		InitializeComponent();
        createPicker();
    }

    private void createPicker()
    {
        List<CourseDetails> cDetail = new List<CourseDetails>(dhelper.GetItems<CourseDetails>());
        courses = new ObservableCollection<CourseDetails>(cDetail);
        coursePicker.ItemsSource = courses;
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }

    private void saveCourseData(object sender, EventArgs e)
    {

    }
}