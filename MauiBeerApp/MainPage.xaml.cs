using PunkApi;

namespace MauiBeerApp;

public partial class MainPage : ContentPage
{
    private MainPageViewModel viewModel;
    private bool firstLoad = true;

    public MainPage(MainPageViewModel viewModel, PunkApiClient punkApiClient )
	{
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
        InitializeComponent();

//        Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
//        {
//#if IOS || MACCATALYST
//                var button = handler.PlatformView;
//                button.BackgroundColor = UIKit.UIColor.DarkGray;
//#elif ANDROID
//                var button = handler.PlatformView;
//                button.SetBackgroundColor(Android.Graphics.Color.DarkGray);
//#endif
//        });
    }

    protected override async void OnAppearing()
    {
        if (firstLoad)
        {
            await viewModel.Init();
            firstLoad = false;
        }
        base.OnAppearing();
    }
}