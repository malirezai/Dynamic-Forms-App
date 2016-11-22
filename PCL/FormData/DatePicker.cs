using System;
namespace PCL
{
	public class DatePicker:FormElement
	{
		public DateTime SelectedDate;
		public string AutomationID;

		public DatePicker()
		{
			SelectedDate = DateTime.Now;
		}
	}
}
