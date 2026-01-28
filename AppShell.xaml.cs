using SignInWorkoutYavin.ViewModels;

namespace SignInWorkoutYavin
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            Routing.RegisterRoute(nameof(FirstPage), typeof(FirstPage));
            Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
        }
    }
}
