using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace EmergencyCall
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected async override void OnStart()
		{
			var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
			if (status != PermissionStatus.Granted)
			{
				var shouldShow = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location);
				if (shouldShow)
				{
					await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
				}
			}
		}

		protected override void OnSleep()
		{

		}

		protected override void OnResume()
		{

		}
	}
}
