using System.Collections.ObjectModel;

namespace DBSimpleCRUDMAUI.NavigationPages;

public partial class courseDetailsSummary : ContentPage
{

    DatabaseHelper dhelper = new DatabaseHelper();
    public ObservableCollection<CourseStudentMapping> courses { get; set; }
    public courseDetailsSummary()
	{
		InitializeComponent();
        LoadData();

    }

    private void LoadData()
    {
        List<CourseStudentMapping> cDetail = new List<CourseStudentMapping>(dhelper.GetItems<CourseStudentMapping>());
        courses = new ObservableCollection<CourseStudentMapping>(cDetail);
        ItemsListView.ItemsSource = courses;
    }
}