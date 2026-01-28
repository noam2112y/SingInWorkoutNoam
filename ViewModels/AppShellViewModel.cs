using SingInWorkoutNoam.Service;
using SingInWorkoutNoam.Views;
using System.Windows.Input;

namespace SingInWorkoutNoam.ViewModels
{
    public class AppShellViewModel
    {
        private Page _signInPage;

        public bool IsAdmin { get => (App.Current as App)?.CurrentUser?.IsAdmin ?? false; }

        public ICommand LogoutCommand { get; }
        public ICommand AdminLoginCommand { get; }

        public AppShellViewModel(SignInPage signInPage)
        {
            _signInPage = signInPage;

            LogoutCommand = new Command(Logout);
            AdminLoginCommand = new Command(OpenAdminLogin);
        }

        private async void OpenAdminLogin(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AdminLoginPage));
        }

        private void Logout(object obj)
        {
            
            (App.Current as App)!.CurrentUser = null;

            AppState.IsAdminLoggedIn = false;
            AppState.AdminUser = null;

            Application.Current.Windows[0].Page = _signInPage;
        }
    }
}
