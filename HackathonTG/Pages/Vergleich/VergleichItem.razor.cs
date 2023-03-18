using HackathonTG.OpenGovernmentData.Core.Models;
using Microsoft.AspNetCore.Components;

namespace HackathonTG.Pages.Vergleich
{
	public partial class VergleichItem
	{
		[Parameter] public IReadOnlyDictionary<string, GemeindeVerbrauch> SuchListe { get; set; }

		private GemeindeVerbrauch GemeindeVerbrauch { get; set; }

		private Task<IEnumerable<GemeindeVerbrauch>> SucheGemeinde(string gemeindeName)
		{
			return Task.FromResult(SuchListe.Where(k => k.Key.StartsWith(gemeindeName ?? string.Empty)).Select(g => g.Value));
		}
	}
}
