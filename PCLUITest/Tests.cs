using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace PCLUITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;
		public bool OnAndroid;
		public bool OniOS;


		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			OnAndroid = app.GetType() == typeof(AndroidApp);
			OniOS = app.GetType() == typeof(iOSApp);
		}

		[Test]
		public void LoginTest()
		{

			app.Screenshot("Given i'm on the login page");
			app.Tap(x => x.Marked("Login"));

			app.Screenshot("And I don't login");
			app.Tap(x => x.Marked("NO!"));

			app.Screenshot("I should see the first page");

			app.EnterText(x => x.Marked("First and last name"), "Mahdi Alirezaie");
			app.DismissKeyboard();

			app.EnterText(x => x.Marked("Job Desc"), "Xamarin TSP");
			app.DismissKeyboard();

			app.Tap(x => x.Marked("Picker1"));
			app.Tap("4");

			if (OniOS)
			{
				app.Tap("Done");
			}

			// tap on submit button

		}

		[Test]
		public void ReplTest()
		{
			app.Repl();
		}
	}
}
