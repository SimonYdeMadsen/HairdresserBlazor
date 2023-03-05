using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HairdresserBlazor.Entities
{
	public class User : IdentityUser<int>
	{
		public enum MembershipType {
			Default,
			Premium
		}

		public MembershipType Membership { get; set; }

		public ICollection<Appointment> UserAppointments { get; set; }
	}

	public class UserRole : IdentityRole<int>
	{
	}
}
