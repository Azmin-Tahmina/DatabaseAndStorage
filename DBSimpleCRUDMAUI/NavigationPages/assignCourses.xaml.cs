using System.Collections.ObjectModel;
using System.Data;

namespace DBSimpleCRUDMAUI.NavigationPages;

public partial class assignCourses : ContentPage
{
    DatabaseHelper dhelper = new DatabaseHelper();
    public ObservableCollection<CourseDetails> courses { get; set; }
    public ObservableCollection<Students> students { get; set; }

    public int courseIdfromPicker;
    public assignCourses()
	{
		InitializeComponent();
        LoadActiveStudents();
        createPicker();
    }

    private void createPicker()
    {
        List<CourseDetails> cDetail = new List<CourseDetails>(dhelper.GetItems<CourseDetails>());
        courses = new ObservableCollection<CourseDetails>(cDetail);
        coursePicker.ItemsSource = courses;
    }

    private void LoadActiveStudents()
    {
        List<Students> std = new List<Students>(dhelper.GetActiveItems<Students>());
        students = new ObservableCollection<Students>(std);
        ItemsListView.ItemsSource = students;
    }
    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Students selectedItem)
        {
            // Load selected item data into entry fields
            cIdEntry.Text = Convert.ToString(selectedItem.id);
            cNameEntry.Text = selectedItem.fullName;
        }
    }


    private void CoursePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedCourse = (CourseDetails)picker.SelectedItem;
        if (selectedCourse != null)
        {
            courseIdfromPicker = selectedCourse.id;
        }
    }
    private async void saveCourseData(object sender, EventArgs e)
    {

        CourseStudentMapping newCourseStudentMapping = new CourseStudentMapping
        {
            studentId = Convert.ToInt32(cIdEntry.Text),
            courseId = Convert.ToInt32(courseIdfromPicker),
        };

        if (newCourseStudentMapping != null)
        {
            if (newCourseStudentMapping.id == 0)
            {

                dhelper.SaveItem<CourseStudentMapping>(newCourseStudentMapping);
            }
            else
            {
                dhelper.UpdateItem<CourseStudentMapping>(newCourseStudentMapping);
            }
        }

        await Shell.Current.GoToAsync("courseDetailsSummary", true);

        //LoadData();
    }

}