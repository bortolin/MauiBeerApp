using PunkApi;

namespace MauiBeerApp;

public partial class MainPage : ContentPage
{
    private MainPageViewModel viewModel;

    public MainPage(MainPageViewModel viewModel, PunkApiClient punkApiClient )
	{
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
        InitializeComponent();
    }
}