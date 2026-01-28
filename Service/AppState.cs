using SingInWorkoutNoam.Models;

namespace SingInWorkoutNoam.Service
{
    public static class AppState
    {
        public static bool IsAdminLoggedIn { get; set; }
        public static User? AdminUser { get; set; }
    }
}
