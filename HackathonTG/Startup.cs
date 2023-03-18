using Microsoft.AspNetCore.Authorization;
using MudBlazor.Services;

namespace pebe.Dashboard
{
	/// <summary>
	/// This methods gets called by the runtime. Use this methods to configure the HTTP request pipeline.
	/// </summary>
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}

		public IConfiguration Configuration { get; }

		public IWebHostEnvironment Environment { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// Blazor
			services.AddRazorPages();
			services.AddServerSideBlazor().AddCircuitOptions(o => o.DetailedErrors = !Environment.IsProduction());

			// MudBlazor
			services.AddMudServices();

			// Services
			HackathonTG.OpenGovernmentData.Core.Startup.ConfigureServices(services, Configuration);

			// ViewModels
			HackathonTG.OpenGovernmentData.Core.Startup.ConfigureViewModels(services);

			// Jobs
			HackathonTG.OpenGovernmentData.Core.Startup.ConfigureJobs(services);
		}

		public void Configure(IApplicationBuilder app)
		{
			// Configure the HTTP request pipeline.
			if (!Environment.IsProduction())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRequestLocalization();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				if (Environment.IsDevelopment())
				{
					endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute());
				}
				else
				{
					endpoints.MapControllers();
				}

				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
