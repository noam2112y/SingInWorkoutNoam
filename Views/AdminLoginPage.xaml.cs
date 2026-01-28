using SingInWorkoutNoam.Models;
using SingInWorkoutNoam.Service;

namespace SingInWorkoutNoam.Views;

public partial class AdminLoginPage : ContentPage
{
    public AdminLoginPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        MsgLabel.IsVisible = false;

        string email = EmailEntry.Text ?? "";
        string pass = PasswordEntry.Text ?? "";

        if (email.Trim() == "" || pass.Trim() == "")
        {
            MsgLabel.Text = "Fill email and password";
            MsgLabel.IsVisible = true;
            return;
        }

        DBMokup db = new DBMokup();

        if (!db.IsExist(email, pass))
        {
            MsgLabel.Text = "Wrong email or password";
            MsgLabel.IsVisible = true;
            return;
        }

        User u = db.GetUserByEmail(email);

        if (u == null || !u.IsAdmin)
        {
            MsgLabel.Text = "Not an admin user";
            MsgLabel.IsVisible = true;
            return;
        }

        // ✅ אדמין התחבר
        AppState.IsAdminLoggedIn = true;
        AppState.AdminUser = u;

        // ✅ מעבירים למסך הרשימה (שם יש את כל פעולות המצגת: מחיקה + שינוי פרטים)
        await Shell.Current.GoToAsync(nameof(UsersListPage));
    }
}
