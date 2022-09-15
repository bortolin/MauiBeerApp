using PunkApi;

namespace MauiBeerApp;

public partial class BeerDetailPage : ContentPage
{
    
	public BeerDetailPage(Beer beer)
	{
        this.BindingContext = beer;
        InitializeComponent();
    }
}