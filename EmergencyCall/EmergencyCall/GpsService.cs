using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EmergencyCall
{
	public class GpsService
	{
		public async Task<Location> GetLocationAsync()
		{
			Location location = null;

			try
			{
			 	 location = await Geolocation.GetLastKnownLocationAsync();

				if (location != null)
				{
					Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
				}
			}
			catch (FeatureNotSupportedException fnsEx)
			{
				// Handle not supported on device exception
			}
			catch (FeatureNotEnabledException fneEx)
			{
				// Handle not enabled on device exception
			}
			catch (PermissionException pEx)
			{
				// Handle permission exception
			}
			catch (Exception ex)
			{
				// Unable to get location
			}

			return location;
		}
	}
}
