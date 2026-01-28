namespace SingInWorkoutNoam.ViewModels;

using SingInWorkoutNoam.Models;
using SingInWorkoutNoam.Service;
using System.Collections.ObjectModel;

public class UsersListPageViewModel : ViewModelBase
{
    private string? _searchText;
    private List<User> _allUsers;

    private ObservableUser? _selectedUser;

    public string? SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<ObservableUser> AllUsers { get; }

    public ObservableUser? SelectedUser
    {
        get => _selectedUser;
        set
        {
            if (_selectedUser != value)
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }
    }

    public Command GetAllUsersCommand { get; }
    public Command SearchCommand { get; }
    public Command ClearFilterCommand { get; }
    public Command DeleteUserCommand { get; }
    public Command ViewAccountPage { get; }

    public Command SelectionChangedCommand { get; }

    public Command AddUserCommand { get; }

    public UsersListPageViewModel()
    {
        AllUsers = new ObservableCollection<ObservableUser>();
        _allUsers = new List<User>();

        GetAllUsersCommand = new Command(GetAllUsers);
        SearchCommand = new Command(OnSearch);
        ClearFilterCommand = new Command(ClearFilter);

        DeleteUserCommand = new Command<ObservableUser>(DeleteUser);
        ViewAccountPage = new Command<ObservableUser>(GoToAccountPage);

        SelectionChangedCommand = new Command(OnSelectionChanged);

        AddUserCommand = new Command(AddUser);

        GetAllUsers();
    }

    private void GetAllUsers()
    {
        _allUsers = new DBMokup().GetUsers();

        AllUsers.Clear();

        int i = 0;
        while (i < _allUsers.Count)
        {
            AllUsers.Add(new ObservableUser(_allUsers[i]));
            i = i + 1;
        }
    }

    private void AddUser()
    {
        User u = new User();
        u.FirstName = "New";
        u.LastName = "User";
        u.UEmail = "newuser@gmail.com";
        u.UMobile = "0500000000";
        u.RegDate = DateTime.Now;
        u.IsAdmin = false;
        u.UserPassword = "1234";

        new DBMokup().AddUser(u);

        GetAllUsers();
    }

    private void DeleteUser(ObservableUser obsUser)
    {
        if (obsUser == null) return;

        new DBMokup().RemoveUser(obsUser.User);
        GetAllUsers();
    }

    private void ClearFilter()
    {
        AllUsers.Clear();

        int i = 0;
        while (i < _allUsers.Count)
        {
            AllUsers.Add(new ObservableUser(_allUsers[i]));
            i = i + 1;
        }
    }

    private void OnSearch()
    {
        if (SearchText == null || SearchText.Trim() == "")
            return;

        string s = SearchText.Trim().ToLower();

        AllUsers.Clear();

        int i = 0;
        while (i < _allUsers.Count)
        {
            string fn = (_allUsers[i].FirstName ?? "").ToLower();
            string ln = (_allUsers[i].LastName ?? "").ToLower();

            if (fn.Contains(s) || ln.Contains(s))
            {
                AllUsers.Add(new ObservableUser(_allUsers[i]));
            }

            i = i + 1;
        }
    }

    private async void GoToAccountPage(ObservableUser obsUser)
    {
        if (obsUser == null) return;

        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("selectedUser", obsUser.User);

        await Shell.Current.GoToAsync(nameof(SingInWorkoutNoam.Views.UserDetailsPage), param);
    }

    private async void OnSelectionChanged()
    {
        if (SelectedUser == null) return;

        Dictionary<string, object> param = new Dictionary<string, object>();
        param.Add("selectedUser", SelectedUser.User);

        await Shell.Current.GoToAsync(nameof(SingInWorkoutNoam.Views.UserDetailsPage), param);

        SelectedUser = null;
    }
}
