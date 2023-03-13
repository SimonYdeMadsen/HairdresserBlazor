using HairdresserBlazor.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HairdresserBlazor.Services
{

    /* https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-7.0#expose-the-authentication-state-as-a-cascading-parameter
		Should probably do this instead. 
     */
    public class UserHandler : IUserHandler
	{
		private readonly AuthenticationStateProvider userProvider;
		private readonly UserManager<User> userManager;

		public UserHandler(AuthenticationStateProvider userProvider, UserManager<User> userManager)
		{
			this.userProvider = userProvider;
			this.userManager = userManager;
		}


		public async Task<int> GetCurrentUserId()
		{
			var result = await userProvider.GetAuthenticationStateAsync();
			var user = result.User;
			var id = int.Parse(userManager.GetUserId(user));
			return id;
		}
	}
}
