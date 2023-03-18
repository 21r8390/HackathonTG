using System.Drawing;

namespace pebe.Common.Core.Utils
{
	public static class ColorUtils
	{
		/// <summary>
		/// Creates color with corrected brightness.
		/// </summary>
		/// <seealso href="https://stackoverflow.com/a/12598573/16632604">Source</seealso>
		/// <param name="color">Color to correct.</param>
		/// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
		/// Negative values produce darker colors.</param>
		/// <returns>
		/// Corrected <see cref="Color"/> structure.
		/// </returns>
		public static Color ChangeBrightnessTo(this Color color, float correctionFactor)
		{
			float red = color.R;
			float green = color.G;
			float blue = color.B;

			if (correctionFactor < 0)
			{
				correctionFactor = 1 + correctionFactor;
				red *= correctionFactor;
				green *= correctionFactor;
				blue *= correctionFactor;
			}
			else
			{
				red = (255 - red) * correctionFactor + red;
				green = (255 - green) * correctionFactor + green;
				blue = (255 - blue) * correctionFactor + blue;
			}

			return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
		}
	}
}
