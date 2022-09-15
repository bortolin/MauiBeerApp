using System.Collections.ObjectModel;
using System.ComponentModel;
using PunkApi;

namespace MauiBeerApp;

public partial class BeersPage : ContentPage
{
    private ObservableCollection<PunkApi.Beer> beersList = new ObservableCollection<PunkApi.Beer>();
    private int page = 1;
    private int pagesize = 30;
    private bool isLoading;
    private bool allLoaded;
    private PunkApiClient _punkApiClient;

    public BeersPage(PunkApiClient punkApiClient)
	{
        _punkApiClient = punkApiClient;

        InitializeComponent();
        this.BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        BeersList = new ObservableCollection<Beer>(await _punkApiClient.GetAllBeersAsync(page, pagesize));
    }

    public ObservableCollection<PunkApi.Beer> BeersList
    {
        get { return beersList; }
        set { beersList = value; OnPropertyChanged(); }
    }

    async void CollectionView_RemainingItemsThresholdReached(System.Object sender, System.EventArgs e)
    {
        if (IsLoading || allLoaded) return;

        IsLoading = true;

        page += 1;
        var newbeer = await _punkApiClient.GetAllBeersAsync(page, pagesize);
        if (newbeer.Count() > 0)
        {
            foreach (var item in newbeer)
            {
                beersList.Add(item);
            }
        }
        else
        {
            allLoaded = true;
        }

        IsLoading = false;
    }

    public bool IsLoading { get { return isLoading; } set { isLoading = value; OnPropertyChanged(); } }

    async void SearchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length <= 3) return;
        IsLoading = true;

        BeersList = new ObservableCollection<Beer>(await _punkApiClient.SerachBeersByNameAsync(e.NewTextValue));

        allLoaded = true;
        IsLoading = false;


    }
}
