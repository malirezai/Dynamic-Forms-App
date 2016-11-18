using System;
using System.Threading.Tasks;
using Foundation;
using PCL.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(PCL.iOS.ResourceiOS))]
namespace PCL.iOS
{
	public class ResourceiOS : IResourceFinder
	{
		public ResourceiOS()
		{
		}

		public /*async Task <string>*/string getFormString(string fileName)
		{
			//await Task.Delay(10);

			var path = NSBundle.MainBundle.PathForResource(fileName, "json");

			var json = "";

			using (var data = NSData.FromFile(path))
			{
				json = NSString.FromData(data, NSStringEncoding.ASCIIStringEncoding).ToString();
			}

			return json;
		}
	}
}
