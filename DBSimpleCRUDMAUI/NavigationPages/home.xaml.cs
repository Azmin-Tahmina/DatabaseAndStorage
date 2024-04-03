using System.Collections.ObjectModel;

namespace DBSimpleCRUDMAUI.NavigationPages;

public partial class home : ContentPage
{

    public ObservableCollection<Students> students { get; set; }
    DatabaseHelper dhelper = new DatabaseHelper();
    //public ObservableCollection<CourseDetails> courses { get; set; }
    //public ObservableCollection<CourseStudentMapping> csMaps { get; set; }
    public home()
	{
		InitializeComponent();


        //students = new ObservableCollection<Students>
        //{
        //    new Students {id=1, firstName="Fname1",lastName="Lname1", age=20, active=true,courseCount=2},
        //    new Students {id=2, firstName="Fname2",lastName="Lname2", age=20, active=true,courseCount=2},
        //    new Students {id=3, firstName="Fname3",lastName="Lname3", age=20, active=true,courseCount=2}
        //};

        //ItemsListView.BindingContext = students;
        LoadData();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Refresh your ObservableCollection here
        // For instance, assuming you have a ViewModel with a method to refresh data:
        LoadData();
    }

    private void LoadData()
    {
        List<Students> std = new List<Students>(dhelper.GetItems<Students>());
        students = new ObservableCollection<Students>(std);
        ItemsListView.ItemsSource = students;
    }
    private void OnSearchClicked(object sender, EventArgs e)
    {
       
    }

    private void OnMoreClicked(object sender, EventArgs e)
    {

    }

    private async void addNewStudent(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("add", true);
    }

    private async void addCoursesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("addCourses", true);
    }

    private async void assignCoursesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("assignCourses", true);
    }

    private async void courseDetailsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("courseDetailsSummary", true);
    }

    private void editStudent(object sender, SelectedItemChangedEventArgs e)
    {

    }
}