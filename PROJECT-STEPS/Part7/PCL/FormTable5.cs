using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace PCL
{
	public class FormTable5
	{
		string id;
		string name;
		bool done;

		[JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FormType { get; set; }
		public string FormData { get; set; }
		public DateTime EnteredDateUTC { get; set;}

		[Version]
		public string Version { get; set; }


		// we're using these two for display purposes
		[JsonIgnore]
		public string DateDisplay { get { return EnteredDateUTC.ToLocalTime().ToString("g"); } }

		[JsonIgnore]
		public string TimeDisplay { get { return EnteredDateUTC.ToLocalTime().ToString("t"); } }

		[JsonIgnore]
		public string FullName { get { return FirstName + " " + LastName; } }

	}
}
