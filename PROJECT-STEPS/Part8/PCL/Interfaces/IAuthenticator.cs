using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PCL.Interfaces
{
	public interface IAuthenticator
	{
		Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri);
	}
}
