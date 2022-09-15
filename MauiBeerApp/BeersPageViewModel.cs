using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PunkApi;

namespace MauiBeerApp
{
    public class BeersPageViewModel : BaseViewModel
    {
        private PunkApiClient punkApiClient;
        private ObservableCollection<PunkApi.Beer> beersList;

        private int currentDataPage = 1;
        private int pageDataSize = 30;

        private bool isLoading;
        private bool allLoaded;

        public bool IsLoading { get { return isLoading; } set { SetProperty(ref isLoading, value); } }
        public ObservableCollection<PunkApi.Beer> BeersList { get { return beersList; } set { SetProperty(ref beersList, value); } }

        public BeersPageViewModel(PunkApiClient punkApiClient)
        {
            this.punkApiClient = punkApiClient;
            BeersList  = new ObservableCollection<PunkApi.Beer>();
        }

        public async Task Init()
        {
            IsLoading = true;
            BeersList = new ObservableCollection<Beer>(await punkApiClient.GetAllBeersAsync(currentDataPage, pageDataSize));
            IsLoading = false;
        }

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            if (string.IsNullOrWhiteSpace(query)) {
                await Init();
            }
            else
            {
                IsLoading = true;
                BeersList = new ObservableCollection<Beer>(await punkApiClient.SerachBeersByNameAsync(query));
                IsLoading = false;
            }
        }, (string query) => { return !IsLoading; });
        
        public ICommand LoadMoreData => new Command(async () =>
        {
            IsLoading = true;

            currentDataPage += 1;

            var newbeer = await punkApiClient.GetAllBeersAsync(currentDataPage, pageDataSize);
            if (newbeer.Count() > 0)
            {
                foreach (var item in newbeer)
                {
                    BeersList.Add(item);
                }
            }
            else
            {
                allLoaded = true;
            }

            IsLoading = false;
        }, () => { return (!IsLoading && !allLoaded); });

        public ICommand SelectedBeerChanged => new Command<Beer>(async (beer) =>
        {
            await Shell.Current.Navigation.PushAsync(new BeerDetailPage(beer));
        });
    }
}