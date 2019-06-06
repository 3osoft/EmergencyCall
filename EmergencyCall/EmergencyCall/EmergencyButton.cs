using System;

namespace EmergencyCall
{
	public class EmergencyButton
	{
		public string Name { get; set; }
		public string Message { get; set; }

		public string FormatMessage(double longitude, double latitude)
		{
			var roundedLongitude = Math.Round(longitude, 6, MidpointRounding.AwayFromZero);
			var roundedLatitude = Math.Round(latitude, 6, MidpointRounding.AwayFromZero);

			var formattedMessage = Message.Replace(GpsMacro.Longitude, roundedLongitude.ToString())
				.Replace(GpsMacro.Latitude, roundedLatitude.ToString());

			return formattedMessage;
		}
	}
}
