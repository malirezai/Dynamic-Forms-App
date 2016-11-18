using System;
using System.IO;
using System.Threading.Tasks;
using PCL.Interfaces;
using formsctx = Xamarin.Forms.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(PCL.Droid.ResourceDroid))]
namespace PCL.Droid
{
	public class ResourceDroid : IResourceFinder
	{
		public ResourceDroid()
		{
		}

		public /*async Task<string>*/ string getFormString(string fileName)
		{
			//await Task.Delay(10);

			var path = $"{fileName}.json";
			var json = "";
			using (var sr = new StreamReader(formsctx.Context.Assets.Open(path)))
			{
				json = sr.ReadToEnd();
			}
			return json;
		}
	}
}
