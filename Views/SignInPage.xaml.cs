using SingInWorkoutNoam.Helper;
using SingInWorkoutNoam.Service;
using SingInWorkoutNoam.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace SingInWorkoutNoam.Views;

public partial class SignInPage : ContentPage
{
    
    public SignInPage(SignInViewModel vm)
	{
		InitializeComponent();
        vm.Navigation = this.Navigation;
        BindingContext = vm;
    }

    
}