using System;
namespace PCL
{
	public class UserModel
	{
		public string firstName;
		public string lastName;
		public string AuthToken;
		public DateTimeOffset authExpiry;

		public UserModel()
		{
			firstName = "";
			lastName = "";
			AuthToken = "";
			authExpiry = new DateTimeOffset();

		}
	}
}
