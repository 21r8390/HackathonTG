using System.Runtime.Serialization;

namespace HackathonTG.OpenGovernmentData.Core.Exceptions
{
	/// <summary>
	/// Diese Exception wird geworfen, wenn das Parsen nicht erfolgreich ist
	/// </summary>
	[Serializable]
	public class ParseException : Exception
	{
		public ParseException()
		{
		}

		public ParseException(string message) : base(message)
		{
		}

		public ParseException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
