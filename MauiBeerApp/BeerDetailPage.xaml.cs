using PunkApi;

namespace MauiBeerApp;

public partial class BeerDetailPage : ContentPage
{
    
	public BeerDetailPage(Beer beer)
	{
		InitializeComponent();
        this.BindingContext = beer;
	}
}
