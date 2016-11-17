using System;
using Xamarin.Forms;

namespace PCL
{
	public class MainPage: MasterDetailPage
	{

		MasterPage masterPage;

		public MainPage()
		{
			masterPage = new MasterPage();

			Master = masterPage;

			Detail = new NavigationPage(new FormsPage());

			masterPage.ListView.ItemSelected += OnItemSelected;

			masterPage.ViewAllSubmissions.Clicked+= ViewAllSubmissions_Clicked;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				if (!((NavigationPage)Detail).CurrentPage.GetType().Equals(typeof(FormsPage)))
				{
					Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FormsPage)));
				}

				((FormsPage)((NavigationPage)Detail).CurrentPage).createForm(item.FormSource);
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}

		void ViewAllSubmissions_Clicked(object sender, EventArgs e)
		{
			IsPresented = false;
			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FormsSubmittedListPageXaml)));

		}
	}
}
