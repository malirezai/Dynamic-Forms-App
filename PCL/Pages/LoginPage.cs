using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin.Forms;
using PCL.Interfaces;
using PCL.Helpers;

namespace PCL
{
	public class LoginPage : ContentPage
	{
		public static string authority = "https://login.windows.net/common";
		public static string ResourceID = Settings.Current.ClientAppID;
		public static string clientId = Settings.Current.MobileAppID; 
		public static string returnUri = Settings.Current.MobileAppUrl;

		private AuthenticationResult authResult = null;


		public LoginPage()
		{
			Title = "Login";

			var loginButton = new Button
			{
				Text = "Login",
				HorizontalOptions = LayoutOptions.CenterAndExpand

			};

			var clearCreds = new Button
			{
				Text = "Clear Credentials",
				HorizontalOptions = LayoutOptions.CenterAndExpand

			};

			clearCreds.Clicked += async (sender, e) =>
			{
				bool clear = await DisplayAlert("Delete User?", $"Delete current user {Settings.Current.CurrentUser.firstName} {Settings.Current.CurrentUser.lastName}?", "Yes", "No");
				if (clear)
				{
					Settings.Current.CurrentUser = new UserModel();
				}
			};

			loginButton.Clicked += async (sender, e) =>
			{

				bool login = await DisplayAlert("Login?","Lets Login with Azure AD!","OK","NO!");

				if (login)
				{
					if (String.IsNullOrEmpty(Settings.Current.CurrentUser.AuthToken))
					{

						App.USING_AUTH = true;
						var auth = DependencyService.Get<IAuthenticator>();

						var data = await auth.Authenticate(authority, ResourceID, clientId, returnUri);

						if (data != null)
						{
							var _firstName = data.UserInfo.GivenName;
							var _lastName = data.UserInfo.FamilyName;
							var _token = data.AccessToken;
							var _expiry = data.ExpiresOn;

							if (!String.IsNullOrEmpty(_token))
							{
								Settings.Current.CurrentUser = new UserModel
								{
									firstName = _firstName,
									lastName = _lastName,
									AuthToken = _token,
									authExpiry = _expiry
								};

							}
						}
						else {
							return;
						}
					}

					await Navigation.PushModalAsync(new MainPage());
					

				}
				else {
					App.USING_AUTH = false;
					await Navigation.PushModalAsync(new MainPage());
				}


			};

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
						loginButton,clearCreds
					}
			};



		}
	}
}
