using SingInWorkoutNoam.Helper;
using SingInWorkoutNoam.Service;
using SingInWorkoutNoam.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SingInWorkoutNoam.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private Page _signupPage;
        private INavigation _navigation;
        private IDBService _db;
        private string _userName;
        private string _password;
        private bool _entryAsPassword = true;
        private bool _signInMessageVisible = false;
        private string _loginMassage;
        private string _passIcon = FontHelper.OPEN_EYE_ICON;

        public INavigation Navigation { get; set; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }
        public ICommand NavigateToSignUpCommand { get; }

        public SignInViewModel(SignUpPage signUpPage, IDBService dBService)
        {
            _signupPage = signUpPage;
            _db = dBService;
            _entryAsPassword = true;
            _signInMessageVisible = false;
            ShowPasswordCommand = new Command(TogglePasswordButton);
            SignInCommand = new Command(SignInButtonClick);
            NavigateToSignUpCommand = new Command(async () => await Navigation!.PushAsync(_signupPage));
        }

        public bool EntryAsPassword
        {
            get { return _entryAsPassword; }
            set
            {
                if (_entryAsPassword != value)
                {
                    _entryAsPassword = value;
                    OnPropertyChanged();
                }

            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsSignInButtonEnabled));
                }
            }
        }
        public string UserPassword
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsSignInButtonEnabled));
                }
            }

        }
        public bool IsSignInButtonEnabled
        {

            get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));

        }

        public bool SignInMessageVisible
        {
            get { return _signInMessageVisible; }
            set
            {
                if (_signInMessageVisible != value)
                {
                    _signInMessageVisible = value;
                    OnPropertyChanged();
                }

            }
        }

        public string LoginMessage
        {
            get { return _loginMassage; }
            set
            {
                if ( _loginMassage != value)
                    
                {
                    _loginMassage = value;
                    OnPropertyChanged();
                }

            }
        }

        public string PassIcon
        {
            get { return _passIcon; }
            set
            {
                if (_passIcon != value)

                {
                    _passIcon = value;
                    OnPropertyChanged();
                }

            }
        }

        private void TogglePasswordButton()
        {
            EntryAsPassword = !EntryAsPassword;

            if (EntryAsPassword)
                PassIcon= FontHelper.CLOSED_EYE_ICON;
            else
                PassIcon= FontHelper.OPEN_EYE_ICON;
        }

        private void SignInButtonClick()
        {
            SignInMessageVisible = true;
            if (_db.IsExist(UserName, UserPassword))
            {
                (App.Current as App)!.CurrentUser = _db.GetUserByEmail(UserName);

                var mainPage = IPlatformApplication.Current!.Services.GetService<AppShell>();
                Application.Current!.Windows[0].Page = mainPage;
            }
            else
            {
                LoginMessage = "user not exist";
            }
        }
    }
}
