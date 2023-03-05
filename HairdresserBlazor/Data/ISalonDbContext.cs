using HairdresserBlazor.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairdresserBlazor.Data
{
	public interface ISalonDbContext
	{
		DbSet<Appointment> Appointments { get; set; }
		DbSet<Hairdresser> Hairdressers { get; set; }
		DbSet<User> Users { get; set; }

		public Task<int> SaveChangesAsync();
	}
}