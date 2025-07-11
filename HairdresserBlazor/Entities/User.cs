﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HairdresserBlazor.Entities
{
	public class User : IdentityUser<int>
	{
		public User(string userName) : base()
		{
			base.UserName = userName;
		}

		public enum MembershipType {
			Default,
			Premium
		}

		public MembershipType Membership { get; set; }
	}

	public class UserRole : IdentityRole<int>
	{
	}
}
