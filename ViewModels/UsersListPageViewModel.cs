namespace SignInWorkoutYavin.ViewModels;

using SignInWorkoutYavin.Models;
using SignInWorkoutYavin.Service;
using System.Collections.ObjectModel;

public class UsersListPageViewModel : ViewModelBase
{
    #region Fields
    private string? _searchText; // Text entered in the search bar
    private List<User> _allUsers = new(); // MUST be initialized
    #endregion

    #region Properties
    public string? SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                OnPropertyChanged();
                ClearFilterCommand?.ChangeCanExecute();
            }
        }
    }

    public ObservableCollection<User> AllUsers { get; }
    #endregion

    #region Commands
    public Command SearchCommand { get; }
    public Command ClearFilterCommand { get; }
    public Command GetAllUsersCommand { get; }
    public Command DeleteUserCommand { get; }
    #endregion

    public UsersListPageViewModel()
    {
        AllUsers = new ObservableCollection<User>();

        DeleteUserCommand = new Command<User>(DeleteUser);
        SearchCommand = new Command(OnSearch);
        ClearFilterCommand = new Command(ClearFilter, () => string.IsNullOrEmpty(SearchText));

        GetAllUsersCommand = new Command(GetAllUsers);
    }

    #region Methods

    private void GetAllUsers()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            _allUsers = new DBMokup().GetUsers();
            AllUsers.Clear();

            foreach (User user in _allUsers)
            {
                AllUsers.Add(user);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void DeleteUser(User user)
    {
        if (user != null)
        {
            AllUsers.Remove(user);
            _allUsers.Remove(user);
        }
    }

    private void ClearFilter()
    {
        AllUsers.Clear();

        foreach (User user in _allUsers)
        {
            AllUsers.Add(user);
        }
    }

    private void OnSearch()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
            return;

        var filteredUsers = _allUsers
            .Where(u => u.FirstName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                     || u.LastName.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
            .ToList();

        AllUsers.Clear();

        foreach (User user in filteredUsers)
        {
            AllUsers.Add(user);
        }
    }

    #endregion
}
