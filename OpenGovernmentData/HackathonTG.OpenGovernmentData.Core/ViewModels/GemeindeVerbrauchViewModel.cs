using HackathonTG.OpenGovernmentData.Core.Models;
using HackathonTG.OpenGovernmentData.Core.Services.Interface;
using System.Collections.Immutable;

namespace HackathonTG.OpenGovernmentData.Core.ViewModels
{
	public class GemeindeVerbrauchViewModel
	{
		private readonly IApiService apiService;

		private IEnumerable<GemeindeVerbrauch> gemeindeVerbrauch;
		public IEnumerable<DateTime> Jahre { get; private set; }
		public IReadOnlyDictionary<string, GemeindeVerbrauch> SuchListe { get; private set; }

		public GemeindeVerbrauchViewModel(IApiService apiService)
		{
			this.apiService = apiService;

			gemeindeVerbrauch = Array.Empty<GemeindeVerbrauch>();
			Jahre = Array.Empty<DateTime>();
			SuchListe = new Dictionary<string, GemeindeVerbrauch>().ToImmutableDictionary();
		}

		public async Task LadeDaten()
		{
			gemeindeVerbrauch = await apiService.GetGemeindeVerbrauch();

			LadeJahre();
			LadeSuchListe(Jahre.Max());
		}

		private void LadeJahre()
		{
			Jahre = gemeindeVerbrauch.Select(g => g.Jahr).Distinct().OrderBy(j => j.Year).ToArray();
		}

		public void LadeSuchListe(DateTime jahr)
		{
			SuchListe = gemeindeVerbrauch.Where(g => g.Jahr == jahr)
				.ToDictionary(g => g.Name);
		}
	}
}
