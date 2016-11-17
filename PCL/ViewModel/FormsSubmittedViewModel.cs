using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PCL
{
	public class FormsSubmittedViewModel : BaseViewModel
	{

		public ObservableCollection<FormTable5> FormList { get; set;}

		public FormsSubmittedViewModel(Page page):base (page)
		{
			Title = "Submitted Forms";
			FormList = new ObservableCollection<FormTable5>();

		}

		private Command getFormsCommand;
		public Command GetFormsCommand
		{
			get
			{
				return getFormsCommand ??
					(getFormsCommand = new Command(async () => await ExecuteGetFormsCommand(), () =>
					{
						return !IsBusy;
					}));
			}
		}

		private async Task ExecuteGetFormsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			GetFormsCommand.ChangeCanExecute();
			try
			{
				FormList.Clear();

				var tempList = await App.azureService.GetForms();
				foreach (var form in tempList)
				{
					FormList.Add(form);
				}

			}
			catch (Exception ex)
			{
				await page.DisplayAlert("Uh Oh :(", "Unable to sync forms", "OK");

			}
			finally
			{
				IsBusy = false;
				GetFormsCommand.ChangeCanExecute();
			}

		}

	}
}
