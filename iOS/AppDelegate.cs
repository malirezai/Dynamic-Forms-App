using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.Azure.Mobile;
using UIKit;

namespace PCL.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			MobileCenter.Configure("68befc9c-64bd-4748-a4a3-47e56f15673f");

			LoadApplication(new App());

			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			return base.FinishedLaunching(app, options);
		}

	}
}
