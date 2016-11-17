using System;
namespace PCL
{
	public class DatePicker:FormElement
	{
		public DateTime SelectedDate;

		public DatePicker()
		{
			SelectedDate = DateTime.Now;
		}
	}
}
