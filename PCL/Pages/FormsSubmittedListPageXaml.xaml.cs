using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PCL
{
	public partial class FormsSubmittedListPageXaml : ContentPage
	{

		FormsSubmittedViewModel viewModel;

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.FormList.Count > 0 || viewModel.IsBusy)
				return;

			viewModel.GetFormsCommand.Execute(null);
		}

		public FormsSubmittedListPageXaml()
		{
			InitializeComponent();

			BindingContext = viewModel = new FormsSubmittedViewModel(this);

			FormsSubmittedList.IsPullToRefreshEnabled = true;

			FormsSubmittedList.Refreshing += (sender, e) =>
			{
				viewModel.GetFormsCommand.Execute(true);
				FormsSubmittedList.IsRefreshing = false;
			};

			FormsSubmittedList.ItemSelected += (sender, e) =>
			{
				// Handle Item selected
			};

		}

		public void OnMore(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
		}
	}
}
