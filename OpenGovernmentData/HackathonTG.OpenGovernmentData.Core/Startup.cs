using HackathonTG.OpenGovernmentData.Core.Services.Impl;
using HackathonTG.OpenGovernmentData.Core.Services.Interface;
using HackathonTG.OpenGovernmentData.Core.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HackathonTG.OpenGovernmentData.Core
{
	public static class Startup
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpClient().AddHttpClient(ApiService.HTTP_CLIENT_NAME);

			services.AddSingleton<IApiService, ApiService>();
		}

		public static void ConfigureViewModels(IServiceCollection services)
		{
			services.AddTransient<GemeindeVerbrauchViewModel>();
		}
	}
}
