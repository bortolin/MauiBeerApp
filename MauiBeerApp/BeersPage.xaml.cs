using System.Collections.ObjectModel;
using System.ComponentModel;
using PunkApi;

namespace MauiBeerApp;

public partial class BeersPage : ContentPage
{
    BeersPageViewModel beersPageViewModel;

    public BeersPage(BeersPageViewModel beersPageViewModel)
	{
        this.beersPageViewModel = beersPageViewModel;
        this.BindingContext = beersPageViewModel;
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await beersPageViewModel.Init();
        base.OnAppearing();
    }
}