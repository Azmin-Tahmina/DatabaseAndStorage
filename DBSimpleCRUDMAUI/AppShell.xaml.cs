using DBSimpleCRUDMAUI.NavigationPages;

namespace DBSimpleCRUDMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("add", typeof(add));
            Routing.RegisterRoute("home", typeof(home));
            Routing.RegisterRoute("addCourses", typeof(addCourses));
            Routing.RegisterRoute("assignCourses", typeof(assignCourses));
            Routing.RegisterRoute("editOrViewStudent", typeof(editOrViewStudent));

        }
    }
}
