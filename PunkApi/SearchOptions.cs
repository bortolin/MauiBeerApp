using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PunkApi
{
	public class SearchOptions
	{
		/*
			abv_gt			number	Returns all beers with ABV greater than the supplied number
			abv_lt			number	Returns all beers with ABV less than the supplied number
			ibu_gt			number	Returns all beers with IBU greater than the supplied number
			ibu_lt			number	Returns all beers with IBU less than the supplied number
			ebc_gt			number	Returns all beers with EBC greater than the supplied number
			ebc_lt			number	Returns all beers with EBC less than the supplied number
			beer_name		string	Returns all beers matching the supplied name (this will match partial strings as well so e.g punk will return Punk IPA), if you need to add spaces just add an underscore (_).
			yeast			string	Returns all beers matching the supplied yeast name, this performs a fuzzy match, if you need to add spaces just add an underscore (_).
			brewed_before	date	Returns all beers brewed before this date, the date format is mm-yyyy e.g 10-2011
			brewed_after	date	Returns all beers brewed after this date, the date format is mm-yyyy e.g 10-2011
			hops			string	Returns all beers matching the supplied hops name, this performs a fuzzy match, if you need to add spaces just add an underscore (_).
			malt			string	Returns all beers matching the supplied malt name, this performs a fuzzy match, if you need to add spaces just add an underscore (_).
			food			string	Returns all beers matching the supplied food string, this performs a fuzzy match, if you need to add spaces just add an underscore (_).
			ids	string		(id|id|...)	Returns all beers matching the supplied ID's. You can pass in multiple ID's by separating them with a | symbol.
		*/

		public double? Abv_gt { get; set; }
        public double? Abv_lt { get; set; }

        public double? Ibu_gt { get; set; }
        public double? Ibv_lt { get; set; }

        public double? Ebc_gt { get; set; }
        public double? Ebc_lt { get; set; }

        public string Beername { get; set; }

        public string Yeast { get; set; }

        public DateTime? BrewedBefore { get; set; }
        
        public DateTime? BrewedAfter { get; set; }
        
        public string Hops { get; set; }
        public string Malt { get; set; }
        public string Food { get; set; }

        public IEnumerable<int> Ids { get; set; }

        public string ToQueryString()
        {
            List<string> searchParams = new List<string>();

            if (Abv_gt.HasValue) searchParams.Add($"abv_gt={Abv_gt}");
            if (Abv_lt.HasValue) searchParams.Add($"abv_lt={Abv_lt}");
            if (Ibu_gt.HasValue) searchParams.Add($"ibu_gt={Ibu_gt}");
            if (Ibv_lt.HasValue) searchParams.Add($"ibu_lt={Ibv_lt}");
            if (Ebc_gt.HasValue) searchParams.Add($"ebc_gt={Ebc_gt}");
            if (Ebc_lt.HasValue) searchParams.Add($"ebc_lt={Ibv_lt}");
            if (!string.IsNullOrWhiteSpace(Beername)) searchParams.Add($"beer_name={Beername}");
            if (!string.IsNullOrWhiteSpace(Yeast)) searchParams.Add($"yeast={Yeast}");
            if (BrewedBefore.HasValue) searchParams.Add($"brewed_before={BrewedBefore.Value.ToString("mm-yyyy")}");
            if (BrewedAfter.HasValue) searchParams.Add($"brewed_after={BrewedAfter.Value.ToString("mm-yyyy")}");
            if (!string.IsNullOrWhiteSpace(Hops)) searchParams.Add($"hops={Hops}");
            if (!string.IsNullOrWhiteSpace(Malt)) searchParams.Add($"malt={Malt}");
            if (!string.IsNullOrWhiteSpace(Food)) searchParams.Add($"food={Food}");
            if (!Ids.IsNullOrEmpty()) searchParams.Add(string.Join("|", Ids));

            var sb = new StringBuilder();

            sb.AppendJoin("&", searchParams);

            return sb.ToString();
        }
    }
}

