using System;
using Xamarin.Forms;
             
namespace PCL
{
	public class FormsPage : ContentPage
	{
		
		public FormsPage()
		{

			JsonSerialize json = new JsonSerialize();
			var _form = json.parseJson();

			var mainLayout = new StackLayout
			{
				Padding = 20
			};

			this.Title = _form.Title;

			foreach (var el in _form.Elements)
			{

				switch (el.Type)
				{
					//Add Label 
					case "Label":

						mainLayout.Children.Add(new Label
						{
							Text = ((FormLabel)el).LabelText,
							FontAttributes = FontAttributes.Bold,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						break;
					//Add Entry	
					case "Entry":
						
						mainLayout.Children.Add(new Label
						{
							Text = ((FormEntryField)el).LabelText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						mainLayout.Children.Add(new Entry
						{
							Placeholder = ((FormEntryField)el).PlaceHolderText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						break;
						
					//Add text field	
					case "TextField":
						mainLayout.Children.Add(new Label
						{
							Text = ((FormTextField)el).LabelText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						mainLayout.Children.Add(new Editor
						{
							//Text = ((FormTextField)el).LabelText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						break;
					case "Picker":
						mainLayout.Children.Add(new Label
						{
							Text = ((Picker)el).LabelText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});

						var _picker = new Xamarin.Forms.Picker();
						_picker.HorizontalOptions = LayoutOptions.FillAndExpand;

						foreach (var option in ((Picker)el).Values)
						{
							_picker.Items.Add(option);
						}

						mainLayout.Children.Add(_picker);

						break;
					case "Switch":

						mainLayout.Children.Add(new Label
						{
							Text = ((FormSwitch)el).LabelText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						mainLayout.Children.Add(new Switch
						{
							IsToggled = ((FormSwitch)el).DefaultValue,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});

						break;
					case "DatePicker":

						mainLayout.Children.Add(new Label
						{
							Text = ((DatePicker)el).LabelText,
							HorizontalOptions = LayoutOptions.FillAndExpand
						});
						mainLayout.Children.Add(new Xamarin.Forms.DatePicker
						{
							HorizontalOptions = LayoutOptions.FillAndExpand
						});

						break;
					default:
						break;
				}

			}

			this.Content = mainLayout;

		}

		async public void getFormAsync()
		{
			
		}

	}
}
