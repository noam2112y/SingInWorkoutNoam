using SingInWorkoutNoam.Models;
using SingInWorkoutNoam.Views;

namespace SingInWorkoutNoam
{
    public partial class App : Application
    {
        private Page _page;
        public User? CurrentUser { get; set; } = null;
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