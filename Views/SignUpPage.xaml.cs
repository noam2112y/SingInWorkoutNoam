//using Android.Widget;
//using Android.Widget;
using CommunityToolkit.Maui.Core;
using SingInWorkoutNoam.Helper;
using System.Windows.Input;

namespace SingInWorkoutNoam.Views;

public partial class SignUpPage : ContentPage
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;
    private string? _mobile;
    private bool _entryAsPassword;
    private string? _passwordIconCode;

    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName != value)
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
    }

    public string? LastName
    {
        get => _lastName;
        set
        {
            if (_lastName != value)
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
    }

    public string? UserEmail
    {
        get => _email;
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }

    public string? UserPassword
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }

    public string? Mobile
    {
        get => _mobile;
        set
        {
            if (_mobile != value)
            {
                _mobile = value;
                OnPropertyChanged();
            }
        }
    }

    public bool EntryAsPassword
    {
        get => _entryAsPassword;
        set
        {
            if (_entryAsPassword != value)
            {
                _entryAsPassword = value;
                OnPropertyChanged();
            }
        }
    }

    public string? PasswordIconCode
    {
        get => _passwordIconCode;
        set
        {
            if (_passwordIconCode != value)
            {
                _passwordIconCode = value;
                OnPropertyChanged();
            }
        }
    }

    //public ICommand? ShowPasswordCommand { get; }
    //public ICommand? SignInCommand { get; }
    public SignUpPage()
	{
		InitializeComponent();
        BindingContext = this;
        _entryAsPassword = true;
        _passwordIconCode = FontHelper.CLOSED_EYE_ICON;

        //ShowPasswordCommand = new Command(TogglePasswordButton);
        //SignInCommand = new Command(SignUp, Validate);
    }

    private void TogglePasswordButton_Clicked(object sender, EventArgs e)
    {
        EntryAsPassword = !EntryAsPassword;
        if (EntryAsPassword)
            PasswordIconCode = FontHelper.OPEN_EYE_ICON;
        else
            PasswordIconCode =  FontHelper.CLOSED_EYE_ICON;
    }

    private void SignUpButton_Clicked(object sender, EventArgs e)
    {
        //Register user into DB
        //Save User to Current User
        //Go to Main Page
        var message = "Hello" + FirstName;
        //Toast.Make(message, ToastDuration.Short).Show();
    }

    private bool Validate()
    {
        return true;
    }
}