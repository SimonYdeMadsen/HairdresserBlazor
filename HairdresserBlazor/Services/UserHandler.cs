﻿using Azure;
using HairdresserBlazor.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;

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

		public async Task<ClaimsPrincipal> GetCurrentUser()
		{
            var result = await userProvider.GetAuthenticationStateAsync();
			var user = result.User;
			return user.Identity.IsAuthenticated ? user : null;
        }

        public int GetId(ClaimsPrincipal user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			var id = int.Parse(userManager.GetUserId(user));
			return id;
		}

		public async Task<int> CreateUser(string userName)
		{
			var user = new User(userName);

			var status = await this.userManager.CreateAsync(user);
			if (!status.Succeeded)
			{
				throw new RequestFailedException("No user was created.");
			}
			/* Do I need to update the authorization state here? 
			 Maybe not, because guest user never needs to sign-in. */

			return user.Id;
		}
	}
}
