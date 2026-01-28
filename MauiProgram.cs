using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SingInWorkoutNoam.Service;
using SingInWorkoutNoam.ViewModels;

namespace SingInWorkoutNoam
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
                });
            #region Dependecy Injection for Views, ViewModels and Sercives
            builder.RegisterViews()
                .RegisterViewModels()
                .RegisterServices();
            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<Views.SignInPage>();
            builder.Services.AddTransient<Views.SignUpPage>();
           
            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<SingInWorkoutNoam.ViewModels.SignInViewModel>();
            builder.Services.AddSingleton<AppShellViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IDBService, DBMokup>();
            builder.Services.AddSingleton<AppShell>();
            return builder;
        }
    }
}
