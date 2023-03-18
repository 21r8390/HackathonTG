using HackathonTG.OpenGovernmentData.Core.Models;
using HackathonTG.OpenGovernmentData.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HackathonTG.Pages.Dashboard
{
    public partial class GemeindeVerbrauchDashboard
    {
        private int Index = -1; //default value cannot be 0 -> first selectedindex is 0.

        [Inject] public GemeindeVerbrauchViewModel ViewModel { get; set; }

        public List<ChartSeries> Series { get; set; }

        public string[] XAxisLabels = { "ErdoelBrennstoffe", "Erdgas", "Elektrizitaet", "HolzEnergie", "FernWaerme", "UmweltWaerme", "TotalVerbrauch"};

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.LadeDaten();
            GetTopGemeinden();
        }

        public void GetTopGemeinden()
        {
            var sortiert = ViewModel.SuchListe.Values
                .OrderBy(s => s.EinwohnerAnzahl)
                .Take(10)
                .ToList();

            Series = new List<ChartSeries>();
            foreach (var gemeinde in sortiert)
            {
                Series.Add(new ChartSeries() { Name = gemeinde.Name, Data = new double[] { gemeinde.ErdoelBrennstoffe, gemeinde.Erdgas, gemeinde.Elektrizitaet, gemeinde.HolzEnergie, gemeinde.FernWaerme, gemeinde.UmweltWaerme, gemeinde.TotalVerbrauch } });
            }

        }
    }
}
