using HackathonTG.OpenGovernmentData.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HackathonTG.Pages.Vergleich
{
	public partial class VergleichBoard
	{
		[Inject] public GemeindeVerbrauchViewModel GemeindeVerbrauchViewModel { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await GemeindeVerbrauchViewModel.LadeDaten();
		}
	}
}
