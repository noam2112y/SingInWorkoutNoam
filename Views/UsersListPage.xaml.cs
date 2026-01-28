using SingInWorkoutNoam.Service;
using SingInWorkoutNoam.ViewModels;

namespace SingInWorkoutNoam.Views;

public partial class UsersListPage : ContentPage
{
    public UsersListPage()
    {
        InitializeComponent();
        BindingContext = new UsersListPageViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!AppState.IsAdminLoggedIn)
        {
            await Shell.Current.GoToAsync(nameof(AdminLoginPage));
            return;
        }

        if (BindingContext is UsersListPageViewModel viewModel)
        {
            viewModel.GetAllUsersCommand.Execute(null);
        }
    }
}
