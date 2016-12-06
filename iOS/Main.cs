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
			MobileCenter.Configure("baed21b7-dfb1-4af5-90ef-1d4af7793678");
			AnalyticsHelpers.Start();

			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}
