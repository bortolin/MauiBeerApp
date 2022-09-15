namespace MauiBeerApp;

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
				fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialIcons");
			})
			.Services.AddTransient<PunkApi.PunkApiClient>()
			.AddTransient<BeersPage>()
			.AddTransient<MainPage>()
			.AddTransient<MainPageViewModel>()
			.AddTransient<BeersPageViewModel>();

        return builder.Build();
	}
}