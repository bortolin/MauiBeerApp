using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PunkApi
{
    /// <summary>
    /// Beer entity
    /// </summary>
	public class Beer
	{
		public Beer() {}

        public int Id { get; set; }

        public string Name { get; set; }

        public string Tagline { get; set; }

        [JsonPropertyName("first_brewed")]
        public string FirstBrewed { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        public double? Abv { get; set; }

        public double? Ibu { get; set; }

        [JsonPropertyName("target_fg")]
        public double? TargetFg { get; set; }

        [JsonPropertyName("target_og")]
        public double? TargetOg { get; set; }

        public double? Ebc { get; set; }

        public double? Srm { get; set; }

        public double? Ph { get; set; }

        [JsonPropertyName("attenuation_level")]
        public double? AttenuationLevel { get; set; }

        public Volume Volume { get; set; }

        [JsonPropertyName("boil_volume")]
        public BoilVolume BoilVolume { get; set; }

        public Method Method { get; set; }

        public Ingredients ingredients { get; set; }

        [JsonPropertyName("food_pairing")]
        public IEnumerable<string> FoodPairing { get; set; }

        [JsonPropertyName("brewers_tips")]
        public string BrewersTips { get; set; }

        [JsonPropertyName("contributed_by")]
        public string ContributedBy { get; set; }
    }

    public class Amount
    {
        public double Value { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }

    public class BoilVolume
    {
        public int Value { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }

    public class Fermentation
    {
        public Temp Temp { get; set; }
    }

    public class Hop
    {
        public string Name { get; set; }
        public Amount Amount { get; set; }
        public string Add { get; set; }
        public string Attribute { get; set; }
    }

    public class Ingredients
    {
        public IEnumerable<Malt> Malt { get; set; }
        public IEnumerable<Hop> Hops { get; set; }
        public string Yeast { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var h in this.Hops)
            {
                sb.AppendLine($"{h.Name} ({h.Amount})");
            }

            foreach (var m in this.Malt)
            {
                sb.AppendLine($"{m.Name} ({m.Amount})");
            }

            sb.AppendLine($"Yeast: {this.Yeast}");

            return sb.ToString();
        }
    }

    public class Malt
    {
        public string Name { get; set; }
        public Amount Amount { get; set; }
    }

    public class MashTemp
    {
        public Temp Temp { get; set; }
        public int? Duration { get; set; }
    }

    public class Method
    {

        public List<MashTemp> mash_temp { get; set; }
        public Fermentation Fermentation { get; set; }
        public string Twist { get; set; }
    }

    public class Temp
    {
        public int? Value { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{Value} {Unit}";
        }
    }

    public class Volume
    {
        public int? Value { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return $"{this.Value} {this.Unit}";
        }
    }
}

