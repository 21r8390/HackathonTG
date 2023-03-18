using System.Drawing;

namespace pebe.Common.Core.Utils
{
	public static class StringUtils
	{
		public static Color ToHexColor(this string colorHexWert)
		{
			return ColorTranslator.FromHtml(colorHexWert);
		}
	}
}
