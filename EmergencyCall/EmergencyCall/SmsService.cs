using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EmergencyCall
{
	public class SmsService
	{
		public async Task SendSmsAsync(string messageText, string recipient)
		{
			try
			{
				var message = new SmsMessage(messageText, new[] { recipient });
				await Sms.ComposeAsync(message);
			}
			catch (FeatureNotSupportedException e)
			{
				// Sms is not supported on this device.
			}
			catch (Exception e)
			{
				// Other error has occurred.
			}
		}
	}
}
