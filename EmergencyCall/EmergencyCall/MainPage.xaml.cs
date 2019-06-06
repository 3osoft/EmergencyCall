using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace EmergencyCall
{
	[DesignTimeVisible(true)]
	public partial class MainPage : ContentPage
	{
		private Dictionary<Button, EmergencyButton> _buttons = new Dictionary<Button, EmergencyButton>();
		private bool _isLoaded;

		public MainPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			if (!_isLoaded)
			{
				Configuration configuration = new Configuration();
				var emergencyButtons = (await configuration.LoadEmergencyButtonsAsync()).ToList();

				foreach (var emergencyButton in emergencyButtons)
				{
					Button button = new Button
					{
						Text = emergencyButton.Name
					};

					ButtonPanel.Children.Add(button);
					button.Clicked += HandleOnEmergencyButtonClicked;

					_buttons.Add(button, emergencyButton);
				}

				_isLoaded = true;
			}
			else
			{
				foreach (var button in ButtonPanel.Children)
				{
					((Button)button).Clicked += HandleOnEmergencyButtonClicked;
				}
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			foreach(var button in ButtonPanel.Children)
			{
				((Button)button).Clicked -= HandleOnEmergencyButtonClicked;
			}
		}

		private async void HandleOnEmergencyButtonClicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			var emergencyButton = _buttons[button];

			GpsService gpsService = new GpsService();
			var location = await gpsService.GetLocationAsync();

			SmsService smsService = new SmsService();
			await smsService.SendSmsAsync(emergencyButton.FormatMessage(location.Longitude, location.Latitude), "112");
		}
	}
}
