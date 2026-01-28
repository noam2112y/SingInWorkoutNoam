using SingInWorkoutNoam.ViewModels;
using SingInWorkoutNoam.Views;

namespace SingInWorkoutNoam
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            Routing.RegisterRoute(nameof(UsersListPage), typeof(UsersListPage));
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
            Routing.RegisterRoute(nameof(AdminLoginPage), typeof(AdminLoginPage)); 
        }
    }
}
