using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PCL
{
	public class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

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
				Title = "Reminders",
				IconSource = "reminders.png",
				FormSource = "form1"
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

			Padding = new Thickness(0, 40, 0, 0);
			Icon = "hamburger.png";
			Title = "Personal Organiser";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
				listView
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
