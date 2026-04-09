using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using DemoProj.MVVM.Views.StudentList;
using DemoProj.MVVM.ViewModels.StudentList;
using DemoProj.Services;

namespace DemoProj
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            
            //StudentList
            builder.Services.AddTransient<StudentListViewModel>();
            builder.Services.AddTransient<StudentListView>();

            //StudentPOPUP
            builder.Services.AddSingleton<StudentPopup>();
            builder.Services.AddSingleton<StudentPopupViewModel>();

            //StudentService
            builder.Services.AddSingleton<IStudentService, StudentMockService>();

            return builder.Build();
        }
    }
}
