using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PunkApi
{
	public class PunkApiClient
	{
        private JsonSerializerOptions jsonOptions;

        public PunkApiClient()
		{
            jsonOptions = new JsonSerializerOptions{
                                    PropertyNameCaseInsensitive = true
                                };
        }

		public async Task<Beer> GetRandomBeerAsync()
		{
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync(ApiSettings.ApiRootEndPoint + "beers/random");
            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();

            var beers  = await JsonSerializer.DeserializeAsync<IEnumerable<Beer>>(contentStream, jsonOptions);

            return beers.FirstOrDefault();
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync(int page, int pageSize)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync(ApiSettings.ApiRootEndPoint + $"beers?page={page}&per_page={pageSize}");
            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();
            //var buffer = await response.Content.ReadAsStringAsync();

            var result =  await JsonSerializer.DeserializeAsync<IEnumerable<Beer>>(contentStream, jsonOptions);


            
            return result;
        }

        public async Task<IEnumerable<Beer>> SerachBeersByNameAsync(string findName)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync(ApiSettings.ApiRootEndPoint + $"beers?beer_name={findName}");
            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();
            //var buffer = await response.Content.ReadAsStringAsync();

            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Beer>>(contentStream, jsonOptions);



            return result;
        }
    }
}

