using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace PCL
{
	public class App : Application
	{
		public static AzureDataService azureService;

		public App()
		{
			
			//create Azure Data Service
			App.azureService = new AzureDataService();

			// The root page of your application
			var content = new ContentPage
			{
				Title = "PCL",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							HorizontalTextAlignment = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};


			MainPage = new MainPage();

		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
