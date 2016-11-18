using System;
using System.Collections.Generic;

namespace PCL
{
	public class FormDefinition
	{
		public string Title;

		public List<FormElement> Elements;

		public FormDefinition()
		{
			Elements = new List<FormElement>();
		}
	}
}
