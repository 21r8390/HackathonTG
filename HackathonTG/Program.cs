using HackathonTG.OpenGovernmentData.Core.Parsers;
using pebe.Dashboard;

namespace HackathonTG
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			using var jsonStream = File.OpenRead("D:\\Entwicklung\\tmp\\verbrauch.json");
			var test = await GemeindeVerbrauchParser.ParseJson(jsonStream);

			//IHost webHost = CreateHostBuilder(args).Build();
			//await webHost.RunAsync();
		}


		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration(builder =>
			{
				builder.AddJsonFile("appsettings.json", false, true);
				// Konfiguration pro Arbeitsstation zulassen
				builder.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);
			})
			.ConfigureWebHostDefaults(webBuilder =>
			{
				// DevExpress
				webBuilder.UseWebRoot("wwwroot");
				webBuilder.UseStaticWebAssets();

				webBuilder.UseStartup<Startup>();
			});
	}
}