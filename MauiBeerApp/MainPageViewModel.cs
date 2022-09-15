using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PunkApi;

namespace MauiBeerApp
{
	public class MainPageViewModel: BaseViewModel
    {
        private PunkApiClient punkApiClient;
        private Beer currentBeer;
        private object currentBeerImageUrl;
        private bool isRefreshing;

        public MainPageViewModel(PunkApiClient punkApiClient)
		{
            this.punkApiClient = punkApiClient;

            DiscoverBeer = new Command(
            execute: async () =>
            {
                await LoadData();
            },
            canExecute: () =>
            {
                return !IsRefreshing;
            });

            OpenBeerDetail = new Command(
            execute: async () =>
            {
                await Shell.Current.Navigation.PushAsync(new BeerDetailPage(CurrentBeer));
            });
            
        }

        public Beer CurrentBeer { get { return currentBeer;  } set { SetProperty(ref currentBeer, value); } }

        public object CurrentBeerImageUrl { get { return currentBeerImageUrl; } set { SetProperty(ref currentBeerImageUrl, value);} }

        public bool IsRefreshing { get { return isRefreshing; } set { SetProperty(ref isRefreshing, value); } }

        public ICommand DiscoverBeer { private set; get; }

        public ICommand OpenBeerDetail { private set; get; }

        private async Task LoadData()
        {
            IsRefreshing = true;

            var beer = await punkApiClient.GetRandomBeerAsync();

            CurrentBeerImageUrl = !string.IsNullOrWhiteSpace(beer.ImageUrl) ? new Uri(beer.ImageUrl) : "beerimage.png";

            CurrentBeer = beer;

            IsRefreshing = false;
        }
    }
}

