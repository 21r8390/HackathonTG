namespace pebe.Common.Core.Utils
{
	public static class DateUtils
	{
		/// <summary>
		/// Eine Auflistung von Werten die zur Ermittlung eines Datums relativ zu einem beliebigen Eingabedatum, siehe <see cref="DateTimeUtils.RelativeDate(DateTime, RelativeDateKind)"/>.
		/// </summary>
		public enum RelativeDateKind
		{
			/// <summary>
			/// Der erste Tag des selben Jahres.
			/// </summary>
			FirstOfYear,
			/// <summary>
			/// Der letzte Tag des selben Jahres.
			/// </summary>
			LastOfYear,
			/// <summary>
			/// Der erste Tag des nächsten Jahres.
			/// </summary>
			FirstOfNextYear,
			/// <summary>
			/// Der letzte Tag des vorherigen Jahres.
			/// </summary>
			LastOfPreviousYear,
			/// <summary>
			/// Der erste Tag des selben Monats.
			/// </summary>
			FirstOfMonth,
			/// <summary>
			/// Der letzte Tag des selben Monats.
			/// </summary>
			LastOfMonth,
			/// <summary>
			/// Der erste Tag des nächsten Monats.
			/// </summary>
			FirstOfNextMonth,
			/// <summary>
			/// Der letzte Tag des vorherigen Monats.
			/// </summary>
			LastOfPreviousMonth,
		}

		/// <summary>
		/// Ermittelt ein Datum relativ zu <paramref name="date"/> mit Berücksichtigung 
		/// der Art des gewünschten Datums (<paramref name="kind"/>) und gibt dieses zurück.
		/// </summary>
		/// <param name="date">Das Datum, welches als Referenz für das zu ermittelnde Datum verwendet wird</param>
		/// <param name="kind">Die Art des relativen Datums, welches gewünscht wird</param>
		/// <returns>Ein Datum relativ zu <paramref name="date"/> mit Berücksichting der Art des gewünschten Datums <paramref name="kind"/>.</returns>
		public static DateTime RelativeDate(this DateTime date, RelativeDateKind kind)
		{
			return kind switch
			{
				RelativeDateKind.FirstOfYear => new DateTime(date.Year, 1, 1, 0, 0, 0, date.Kind),
				RelativeDateKind.LastOfYear => new DateTime(date.Year, 12, 31, 0, 0, 0, date.Kind),
				RelativeDateKind.FirstOfMonth => new DateTime(date.Year, date.Month, 1, 0, 0, 0, date.Kind),

				// der letzte Tag des Monats ist gleich dem ersten Tag des nächsten Monats minus 1 Tag
				RelativeDateKind.LastOfMonth => date.RelativeDate(RelativeDateKind.FirstOfNextMonth).AddDays(-1),
				RelativeDateKind.FirstOfNextMonth => date.AddMonths(1).RelativeDate(RelativeDateKind.FirstOfMonth),
				RelativeDateKind.LastOfPreviousMonth => date.RelativeDate(RelativeDateKind.FirstOfMonth).AddDays(-1),

				RelativeDateKind.LastOfPreviousYear => date.RelativeDate(RelativeDateKind.FirstOfYear).AddDays(-1),
				RelativeDateKind.FirstOfNextYear => date.AddYears(1).RelativeDate(RelativeDateKind.FirstOfYear),

				_ => throw new NotImplementedException($"Relatives Datum '{kind}' ist nicht implementiert"),
			};
		}

		/// <summary>
		/// Ermittelt die Anzahl der Tage zwischen zwei Datumsangaben.
		/// </summary>
		/// <param name="date"></param>
		/// <param name="otherDate"></param>
		/// <returns>Die absolute Anzahl der Tage zwischen den Daten.</returns>
		public static int DaysBetween(this DateTime date, DateTime otherDate)
		{
			return Math.Abs((int)(date - otherDate).TotalDays);
		}

		/// <summary>
		/// Ermittelt, ob ein Datum zwischen einer Zeitspanne (Von <paramref name="start"/> bis <paramref name="end"/>) liegt.
		/// </summary>
		/// <param name="date">Das Datu, welches als Referenz für die Ermittlung verwendet wird</param>
		/// <param name="start">Das Startdatum, bei welchem die Zeitspanne beginnt</param>
		/// <param name="end">Das Enddatum, bei welchem die Zeitspanne endet</param>
		/// <returns>Ob das Datum zwischen der Zeitspanne liegt.</returns>
		/// <exception cref="ArgumentException">Wenn das Startdatum nach dem Enddatum liegt</exception>
		public static bool IsBetween(this DateTime date, DateTime start, DateTime end)
		{
			if (start > end)
			{
				throw new ArgumentException("Startdatum muss vor dem Enddatum liegen", nameof(start));
			}

			return date >= start && date <= end;
		}
	}
}
