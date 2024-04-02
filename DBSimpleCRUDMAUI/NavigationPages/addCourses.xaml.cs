using System.Collections.ObjectModel;

namespace DBSimpleCRUDMAUI.NavigationPages;

public partial class addCourses : ContentPage
{

    DatabaseHelper dhelper = new DatabaseHelper();
    public ObservableCollection<CourseDetails> courses { get; set; }

    public addCourses()
	{
		InitializeComponent();
        LoadData();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadData();
    }

    private void LoadData()
    {
        List<CourseDetails> cDetail = new List<CourseDetails>(dhelper.GetItems<CourseDetails>());
        courses = new ObservableCollection<CourseDetails>(cDetail);
        ItemsListView.ItemsSource = courses;
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is CourseDetails selectedItem)
        {
            // Load selected item data into entry fields
            cIdEntry.Text = Convert.ToString(selectedItem.id);
            cNameEntry.Text = selectedItem.courseName;
            cDescEntry.Text = selectedItem.courseDescription;
            
        }
    }
    private void saveCourseData(object sender, EventArgs e)
    {
        CourseDetails newCourse = new CourseDetails
        {
            id = Convert.ToInt32(cIdEntry.Text),
            courseName = cNameEntry.Text,
            courseDescription = cDescEntry.Text,
        };

        if(newCourse != null)
        {
            if(newCourse.id == 0)
            {
                
                dhelper.SaveItem<CourseDetails>(newCourse);
            }
            else
            {
                dhelper.UpdateItem<CourseDetails>(newCourse);
            }
        }
   
        LoadData();

    }
}