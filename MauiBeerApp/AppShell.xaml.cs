namespace MauiBeerApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("BeerDetailPage", typeof(BeerDetailPage));
    }
}

