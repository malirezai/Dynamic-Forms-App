using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Microsoft.Azure.Mobile;
using UIKit;

namespace PCL.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			//MobileCenter.Configure("68befc9c-64bd-4748-a4a3-47e56f15673f");
			//AnalyticsHelpers.Start();

			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}
