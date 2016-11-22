using System;
using System.Collections.Generic;
using Xamarin.Forms;
using PCL.Helpers;

namespace PCL
{
	public class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }
		public Button Logout;

		ListView listView;

		public MasterPage()
		{
			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Form 1",
				IconSource = "contacts.png",
				FormSource = "form1"
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Form 2",
				IconSource = "todo.png",
				FormSource = "form2"
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Form 3",
				IconSource = "reminders.png",
				FormSource = "form3"
			});

			listView = new ListView
			{
				ItemsSource = masterPageItems,
				ItemTemplate = new DataTemplate(() =>
				{
					var imageCell = new ImageCell();
					imageCell.SetBinding(TextCell.TextProperty, "Title");
				
					//imageCell.set(ImageCell.ImageSourceProperty, "IconSource");
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None
			};

			Logout = new Button
			{
				Text = "Logout",
				HorizontalOptions = LayoutOptions.Center
			};

			var userModel = Settings.Current.CurrentUser;

			var _user = new Label
			{
				Text = userModel.firstName + " " + userModel.lastName,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};


			Padding = new Thickness(0, 40, 0, 0);
			Icon = "hamburger.png";
			Title = "Forms";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
				_user,listView,Logout

			}
			};



		}
	}

	class MasterPageItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public string FormSource { get; set; }
	}
}
