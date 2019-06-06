using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmergencyCall
{
	public class Configuration
	{
		public Task<IEnumerable<EmergencyButton>> LoadEmergencyButtonsAsync()
		{
			return Task.Run(() =>
			{
				var assembly = typeof(Configuration).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream("EmergencyCall.Configuration.json");
				using (var reader = new StreamReader(stream))
				{
					string config = reader.ReadToEnd();
					var buttons = JsonConvert.DeserializeObject<IEnumerable<EmergencyButton>>(config);
					return buttons;
				}
			});
		}
	}
}
