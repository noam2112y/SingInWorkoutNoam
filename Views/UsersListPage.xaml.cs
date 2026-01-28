namespace SignInWorkoutYavin.Views;

using SignInWorkoutYavin.Models;
using SignInWorkoutYavin.ViewModels;
public partial class UsersListPage : ContentPage
{
    public Command? DeleteUserCommand { get; }
    public UsersListPage()
    {
        InitializeComponent();
        BindingContext = new UsersListPageViewModel();
    }
       
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Optionally, you can call a method to load data when the page appears
        if (BindingContext is UsersListPageViewModel viewModel)
        {

            viewModel.GetAllUsersCommand?.Execute(null);

        }
    }

}