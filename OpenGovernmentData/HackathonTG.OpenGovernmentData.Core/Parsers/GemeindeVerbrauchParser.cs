using HackathonTG.OpenGovernmentData.Core.Exceptions;
using HackathonTG.OpenGovernmentData.Core.Models;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HackathonTG.OpenGovernmentData.Core.Parsers
{
	internal static class GemeindeVerbrauchParser
	{
		private static readonly JsonSerializerOptions jsonOptions = new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			AllowTrailingCommas = true,
			IgnoreReadOnlyProperties = true,
		};

		public static async Task<IEnumerable<GemeindeVerbrauch>> ParseJsonAsync(Stream jsonStream)
		{
			var parsed = await JsonSerializer.DeserializeAsync<List<GemeindeVerbrauchParse>>(jsonStream, jsonOptions);

			if (parsed is null || !parsed.Any())
			{
				throw new ParseException("Das JSON enthält keine oder falsche Daten!");
			}

			return parsed.Select(p => new GemeindeVerbrauch()
			{
				Name = p.Name ?? string.Empty,
				EinwohnerAnzahl = p.EinwohnerAnzahl ?? -1,
				Jahr = DateTime.ParseExact(p.JahrString ?? string.Empty, "yyyy", CultureInfo.InvariantCulture),
				EnergieBezugsFlaeche = p.EnergieBezugsFlaeche ?? -1,
				TotalVerbrauch = p.TotalVerbrauch ?? 0,
				ErdoelBrennstoffe = p.ErdoelBrennstoffe ?? 0,
				Erdgas = p.Erdgas ?? 0,
				Elektrizitaet = p.Elektrizitaet ?? 0,
				HolzEnergie = p.HolzEnergie ?? 0,
				FernWaerme = p.FernWaerme ?? 0,
				UmweltWaerme = p.UmweltWaerme ?? 0,
				SolarWaerme = p.SolarWaerme ?? 0,
				SonstigeEnergie = p.SonstigeEnergie ?? 0,
			}).ToList();
		}

		private sealed class GemeindeVerbrauchParse
		{
			[JsonPropertyName("gemeinde_name")]
			public string Name { get; set; } = string.Empty;
			[JsonPropertyName("einwohner")]
			public int? EinwohnerAnzahl { get; set; }
			[JsonPropertyName("jahr")]
			public string JahrString { get; set; } = string.Empty;
			[JsonPropertyName("energiebezugsflaeche")]
			public double? EnergieBezugsFlaeche { get; set; }

			// Förderbereiche
			[JsonPropertyName("total")]
			public double? TotalVerbrauch { get; set; }

			[JsonPropertyName("erdoelbrennstoffe")]
			public double? ErdoelBrennstoffe { get; set; }
			[JsonPropertyName("erdgas")]
			public double? Erdgas { get; set; }
			[JsonPropertyName("elektrizitaet")]
			public double? Elektrizitaet { get; set; }
			[JsonPropertyName("holzenergie")]
			public double? HolzEnergie { get; set; }

			[JsonPropertyName("fernwaerme")]
			public double? FernWaerme { get; set; }
			[JsonPropertyName("umweltwaerme")]
			public double? UmweltWaerme { get; set; }
			[JsonPropertyName("solarwaerme")]
			public double? SolarWaerme { get; set; }

			[JsonPropertyName("andere")]
			public double? SonstigeEnergie { get; set; }
		}
	}
}
