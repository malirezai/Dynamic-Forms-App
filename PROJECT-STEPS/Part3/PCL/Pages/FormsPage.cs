using System;
using Xamarin.Forms;
             
namespace PCL
{
	public class FormsPage : ContentPage
	{
		JsonSerialize json = new JsonSerialize();

		FormDefinition definition;

		public FormsPage()
		{
			createForm("form1");

		}

		async public void getFormAsync()
		{
			
		}

		public void buildForm()
		{

			var mainLayout = new StackLayout
			{
				Padding = 20
			};


			this.Title = definition.Title;

			foreach (var el in definition.Elements)
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

					// ADD Switch
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

					// Add Datepicker
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

			this.Content = new ScrollView
			{
				Content = mainLayout
			};

		}

		public void createForm(string path)
		{

			definition = json.parseJson(path);

			buildForm();

		}

	}
}
