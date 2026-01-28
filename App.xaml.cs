using SignInWorkoutYavin.Models;
using SignInWorkoutYavin.Views;

namespace SignInWorkoutYavin
{
    public partial class App : Application
    {
        private Page _page;
        public AppUser? CurrentUser { get; set; } = null;
        public bool IsDebugMode { get; set; } = true;
        public App(SignInPage page)
        {
            _page = page;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {                      
            return new Window(new NavigationPage(_page));                         
        }
    }
}