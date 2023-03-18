namespace HackathonTG.OpenGovernmentData.Core.Models
{
	public class GemeindeVerbrauch
	{
		public string Name { get; init; } = string.Empty;
		public int EinwohnerAnzahl { get; init; }
		public DateTime Jahr { get; init; } = DateTime.MinValue;
		public double EnergieBezugsFlaeche { get; init; }

		// Förderbereiche
		public double TotalVerbrauch { get; init; }

		public double ErdoelBrennstoffe { get; init; }
		public double Erdgas { get; init; }
		public double Elektrizitaet { get; init; }
		public double HolzEnergie { get; init; }

		public double FernWaerme { get; init; }
		public double UmweltWaerme { get; init; }
		public double SolarWaerme { get; init; }

		public double SonstigeEnergie { get; init; }
	}
}
