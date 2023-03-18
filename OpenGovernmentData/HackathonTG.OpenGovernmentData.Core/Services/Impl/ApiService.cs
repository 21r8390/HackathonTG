using HackathonTG.OpenGovernmentData.Core.Models;
using HackathonTG.OpenGovernmentData.Core.Parsers;
using HackathonTG.OpenGovernmentData.Core.Services.Interface;

namespace HackathonTG.OpenGovernmentData.Core.Services.Impl
{
	internal class ApiService : IApiService
	{
		public const string HTTP_CLIENT_NAME = "OGD-ApiService";

		private readonly IHttpClientFactory httpClientFactory;

		public ApiService(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}

		public async Task<IEnumerable<GemeindeVerbrauch>> GetGemeindeVerbrauch()
		{
			const string GEMEINDE_VERBRAUCH_URL = @"https://data.tg.ch/api/explore/v2.1/catalog/datasets/div-energie-5/exports/json?lang=en&timezone=Europe%2FZurich";

			using var client = httpClientFactory.CreateClient(HTTP_CLIENT_NAME);
			using var stream = await client.GetStreamAsync(GEMEINDE_VERBRAUCH_URL);

			return await GemeindeVerbrauchParser.ParseJsonAsync(stream);
		}
	}
}
