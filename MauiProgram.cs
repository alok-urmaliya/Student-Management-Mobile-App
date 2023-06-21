using App01.Services;
using App01.View;
using App01.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App01;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//Services
		builder.Services.AddSingleton<IStudentService, StudentService>();

		//Views Registration
		builder.Services.AddSingleton<StudentList>();
		builder.Services.AddSingleton<AddStudent>();

		//ViewModel Registration
		builder.Services.AddSingleton<StudentListViewModel>();
        builder.Services.AddSingleton<AddStudentViewModel>();

        return builder.Build();
	}
}
