using SingInWorkoutNoam.Models;
using SingInWorkoutNoam.Service;


namespace SingInWorkoutNoam.Views;

[QueryProperty(nameof(ReceivedUser), "selectedUser")]
public partial class UserDetailsPage : ContentPage
{
    private User _receivedUser;

    public User ReceivedUser
    {
        get => _receivedUser;
        set
        {
            if (_receivedUser != value)
            {
                _receivedUser = value;
                LoadUserDetails(_receivedUser);
            }
        }
    }

    public UserDetailsPage()
    {
        InitializeComponent();
    }

    private void LoadUserDetails(User user)
    {
        FirstNameEntry.Text = user.FirstName ?? "";
        LastNameEntry.Text = user.LastName ?? "";
        EmailEntry.Text = user.UEmail ?? "";
        MobileEntry.Text = user.UMobile ?? "";
    }

    private async void UpdateButton_Clicked(object sender, EventArgs e)
    {
        User user = new User
        {
            Id = ReceivedUser.Id,  
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            UEmail = EmailEntry.Text,
            UMobile = MobileEntry.Text
        };

        new DBMokup().UpdateUser(user);
        await Shell.Current.GoToAsync("..");
    }

    
}
