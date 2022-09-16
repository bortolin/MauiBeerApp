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
#if IOS || ANDROID
        ToggleShake();
#endif
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
#if IOS || ANDROID
        ToggleShake();
#endif
        base.OnDisappearing();
    }

#if IOS || ANDROID
    private void ToggleShake()
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on compass
                Accelerometer.Default.ShakeDetected += Accelerometer_ShakeDetected;
                //Accelerometer.Default.ReadingChanged += Default_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.Game);
            }
            else
            {
                // Turn off compass
                Accelerometer.Default.Stop();
                Accelerometer.Default.ShakeDetected -= Accelerometer_ShakeDetected;
                //Accelerometer.Default.ReadingChanged -= Default_ReadingChanged;
            }
        }
    }

    //private void Default_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    //{
    //    if (e.Reading.Acceleration.X > 0.2)
    //        viewModel.DiscoverBeer.Execute(null);
    //}

    private void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
        viewModel.DiscoverBeer.Execute(null);
    }
#endif

}