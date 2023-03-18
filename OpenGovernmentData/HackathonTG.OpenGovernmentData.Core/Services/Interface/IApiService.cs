using HackathonTG.OpenGovernmentData.Core.Models;

namespace HackathonTG.OpenGovernmentData.Core.Services.Interface
{
	public interface IApiService
	{
		Task<IEnumerable<GemeindeVerbrauch>> GetGemeindeVerbrauch();
	}
}
