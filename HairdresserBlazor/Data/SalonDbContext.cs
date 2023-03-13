using HairdresserBlazor.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairdresserBlazor.Data
{
	public class SalonDbContext : IdentityDbContext<User, UserRole, int>, ISalonDbContext
	{
		public override DbSet<User> Users { get; set; }
		public DbSet<Hairdresser> Hairdressers { get; set; }
		public DbSet<Appointment> Appointments { get; set; }

		public SalonDbContext(DbContextOptions<SalonDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//// Create User data. 
			//modelBuilder.Entity<User>().HasData(new User
			//{
			//	Id = 1,
			//	Email = "id0@gmail.com",
			//	Membership = User.MembershipType.Default
			//});
			//modelBuilder.Entity<User>().HasData(new User
			//{
			//	Id = 2,
			//	Email = "id1@gmail.com",
			//	Membership = User.MembershipType.Default
			//});
			//modelBuilder.Entity<User>().HasData(new User
			//{
			//	Id = 3,
			//	Email = "id2@gmail.com",
			//	Membership = User.MembershipType.Premium
			//});


			//// Create Hairdresser data.
			//modelBuilder.Entity<Hairdresser>().HasData(new Hairdresser
			//{
			//	Id = 1,
			//	Name = "Driah Resser"
			//});
			//modelBuilder.Entity<Hairdresser>().HasData(new Hairdresser
			//{
			//	Id = 2,
			//	Name = "Yug Nolas"
			//});


			// Create Appointment data
			var today = DateTime.Today;
			modelBuilder.Entity<Appointment>().HasData(new Appointment
			{
				Id = 1,
				UserId = 1,
				HairdresserId = 2,
				StartTime = new DateTime(today.Year, today.Month, today.Day,
										10, 30, 0),
				EndTime = new DateTime(today.Year, today.Month, today.Day,
										11, 00, 0)
			});
			modelBuilder.Entity<Appointment>().HasData(new Appointment
			{
				Id = 2,
				UserId = 1,
				HairdresserId = 2,
				StartTime = new DateTime(today.Year, today.Month, today.Day,
							11, 30, 0),
				EndTime = new DateTime(today.Year, today.Month, today.Day,
										12, 00, 0)
			});
			modelBuilder.Entity<Appointment>().HasData(new Appointment
			{
				Id = 3,
				UserId = 1,
				HairdresserId = 1,
				StartTime = new DateTime(today.Year, today.Month, today.Day,
										10, 30, 0), /* Overlapping timeslot. */
				EndTime = new DateTime(today.Year, today.Month, today.Day,
										11, 00, 0)
			});
			modelBuilder.Entity<Appointment>().HasData(new Appointment
			{
				Id = 4,
				UserId = 3,
				HairdresserId = 1,
				StartTime = new DateTime(today.Year, today.Month, today.Day,
							8, 0, 0), /* Overlapping timeslot. */
				EndTime = new DateTime(today.Year, today.Month, today.Day,
							8, 30, 0)
			});
			// Add future appointment.
			var date = today.AddMonths(1);
			modelBuilder.Entity<Appointment>().HasData(new Appointment
			{
				Id = 5,
				UserId = 3,
				HairdresserId = 1,
				StartTime = new DateTime(date.Year, date.Month, date.Day,
				8, 0, 0), /* Overlapping timeslot. */
				EndTime = new DateTime(date.Year, date.Month, date.Day,
				8, 30, 0)
			});

			// Add past appointment.
			date = today.AddMonths(-1);
			modelBuilder.Entity<Appointment>().HasData(new Appointment
			{
				Id = 6,
				UserId = 3,
				HairdresserId = 1,
				StartTime = new DateTime(date.Year, date.Month, date.Day,
				8, 0, 0), /* Overlapping timeslot. */
				EndTime = new DateTime(date.Year, date.Month, date.Day,
				8, 30, 0)
			});

		}




		public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();


	}
}