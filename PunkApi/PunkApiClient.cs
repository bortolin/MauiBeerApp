using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PunkApi
{
    /// <summary>
    /// Api client for https://api.punkapi.com/v2/
    /// </summary>
	public class PunkApiClient
	{
        private JsonSerializerOptions jsonOptions;

        public PunkApiClient()
		{
            jsonOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
        }

        /// <summary>
        /// Get random beer 
        /// </summary>
        /// <returns>Beer</returns>
		public async Task<Beer> GetRandomBeerAsync()
		{
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync(ApiSettings.ApiRootEndPoint + "beers/random");
            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();

            var beers  = await JsonSerializer.DeserializeAsync<IEnumerable<Beer>>(contentStream, jsonOptions);

            return beers.FirstOrDefault();
        }

        /// <summary>
        /// Get all beer with pagination
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <param name="pageSize">Number of record per page</param>
        /// <returns>List of Beers</returns>
        public async Task<IEnumerable<Beer>> GetAllBeersAsync(int page, int pageSize)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync(ApiSettings.ApiRootEndPoint + $"beers?page={page}&per_page={pageSize}");
            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();

            var result =  await JsonSerializer.DeserializeAsync<IEnumerable<Beer>>(contentStream, jsonOptions);

            return result;
        }

        /// <summary>
        /// Search beers by name
        /// </summary>
        /// <param name="findName">Search string</param>
        /// <returns>Lits of Beers or empty list if no matched</returns>
        public async Task<IEnumerable<Beer>> SerachBeersByNameAsync(string findName)
        {
            using var httpClient = new HttpClient();

            using var response = await httpClient.GetAsync(ApiSettings.ApiRootEndPoint + $"beers?beer_name={findName}");
            response.EnsureSuccessStatusCode();

            using var contentStream = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Beer>>(contentStream, jsonOptions);

            return result;
        }
    }
}

