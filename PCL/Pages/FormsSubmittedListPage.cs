using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PCL
{
	public class FormsSubmittedListPage : ContentPage
	{

		public ListView FormsSubmittedList;

		public ObservableCollection<FormTable5> _formsList;

		public FormsSubmittedListPage()
		{
			BindingContext = this;

			Title = "Submitted Forms";

			#region Forms Submitted List

			_formsList = new ObservableCollection<FormTable5>();

			FormsSubmittedList = new ListView
			{
				ItemsSource = _formsList,
				ItemTemplate = new DataTemplate(() =>
				{
					var textCell = new TextCell();
					textCell.SetBinding(TextCell.TextProperty, "FullName");
					textCell.SetBinding(TextCell.DetailProperty, "DateDisplay");
					//imageCell.set(ImageCell.ImageSourceProperty, "IconSource");
					return textCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None
			};

			FormsSubmittedList.IsPullToRefreshEnabled = true;

			FormsSubmittedList.Refreshing += async (sender, e) =>
			{
				_formsList.Clear();

				try
				{
					IsBusy = true;
					var tempList = await App.azureService.GetForms();

					foreach (var form in tempList)
					{
						_formsList.Add(form);
					}

				}
				catch (Exception ex) {

					await DisplayAlert("Uh Oh :(", "Unable to sync forms", "OK");
				
				}
				finally
				{
					IsBusy = false;
					//OnPropertyChanged(typeof(_formsList));
				}
			};

			#endregion

			#region Refreshing Indicator
			var activityLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				Padding = 10, 
				Spacing = 10,
				Orientation = StackOrientation.Horizontal
			};

			#endregion

			FormsSubmittedList.BeginRefresh();

			Content = FormsSubmittedList;

		}
	}
}
