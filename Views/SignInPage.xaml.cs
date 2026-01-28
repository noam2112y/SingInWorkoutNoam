using SignInWorkoutYavin.Helper;
using SignInWorkoutYavin.Service;
using SignInWorkoutYavin.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace SignInWorkoutYavin.Views;

public partial class SignInPage : ContentPage
{
    
    public SignInPage(SignInViewModel vm)
	{
		InitializeComponent();
        vm.Navigation = this.Navigation;
        BindingContext = vm;
    }

    
}