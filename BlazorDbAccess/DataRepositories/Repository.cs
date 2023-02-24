using BlazorDbAccess.Data;
using BlazorDbAccess.DataRepositories.Contracts;
using BlazorDbAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using BlazorDbAccess.Utility;

namespace BlazorDbAccess.DataRepositories
{
    public class Repository : IHairdresserRepository, IUserRepository, IAppointmentRepository
	{

		private readonly IDbContextFactory<SalonDbContext> DbFactory;

		public Repository(IDbContextFactory<SalonDbContext> dbFactory)
		{
			this.DbFactory = dbFactory;
		}

		public async Task<IEnumerable<Hairdresser>> GetHairdressers()
		{
			using var dbContext = DbFactory.CreateDbContext();

			return await dbContext.Hairdressers
				.ToListAsync();
		}

		public async Task<IEnumerable<int>> GetHairdresserIds() { 

			var hairdressers = await GetHairdressers();
			return hairdressers.Select(h => h.Id);
		}

		public async Task<Hairdresser> GetHairdresser(int hairdresserId)
		{
			using var dbContext = DbFactory.CreateDbContext();
			return await dbContext.Hairdressers
				.Where(h => h.Id == hairdresserId)
				.SingleOrDefaultAsync();
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			using var dbContext = DbFactory.CreateDbContext();
			return await dbContext.Users
				.ToListAsync();
		}

		public async Task<User> GetUser(int userId)
		{
			using var dbContext = DbFactory.CreateDbContext();
			return await dbContext.Users
				.Where(u => u.Id == userId)
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Appointment>> GetHairdresserAppointments(int hairdresserId)
		{
			using var dbContext = DbFactory.CreateDbContext();
			return await dbContext.Appointments
				.Where(a => a.HairdresserId == hairdresserId)
				.ToListAsync();
		}

		public async Task<Appointment> GetAppointment(int appointmentId)
		{
			using var dbContext = DbFactory.CreateDbContext();
			return await dbContext.Appointments
				.Where(a => a.Id == appointmentId)
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Appointment>> GetUserAppointments(int userId)
		{

			// Might be slow to search through all appointments. Maybe add Collection in User?
			using var dbContext = DbFactory.CreateDbContext();
			var userAppointments = await dbContext.Appointments
				.Where(a => a.UserId == userId)
				.ToListAsync();

			throw new NotImplementedException();

		}

		public async Task<Appointment> AddAppointment(int userId, int hairdresserId,
													DateTime startTime, DateTime endTime)
		{
			// TODO: Check if duplicate.

			// TODO: Implement initial constraints on the timeslot. Might be irrelevant due to client implementations. 

			// TODO: Check if timeslot available. Could possibly be done on the client through display options.  

			using var dbContext = DbFactory.CreateDbContext();
			var result = await dbContext.Appointments
				.AddAsync(new Appointment
				{
					UserId = userId,
					HairdresserId = hairdresserId,
					StartTime = startTime,
					EndTime = endTime
				});

			await dbContext.SaveChangesAsync();

			var user = await dbContext.Users.FindAsync(userId);
			user.UserAppointments.Add(result.Entity);


			return result.Entity;
		}

		public async Task<IEnumerable<Appointment>> GetWeeklyAppointments(DateTime date)
		{
			using var dbContext = DbFactory.CreateDbContext();

			var weekStartDate = CalendarUtility.GetNormalizedWeekStartDate(date);
			var weekEndDate = weekStartDate.AddDays(7);

			// Consider using an index on StartDate.
			var weeklyAppointments = await dbContext.Appointments
				.Where(a => a.StartTime.Date > weekStartDate && a.StartTime.Date < weekEndDate)
				.ToListAsync();

			return weeklyAppointments;
		}

		public async Task<List<Appointment>> GetWeeklyHairdresserAppointments(DateTime date, int hairdresserId)
		{
			var weeklyAppointments = await GetWeeklyAppointments(date);
			return weeklyAppointments
				.Where(a => a.HairdresserId == hairdresserId)
				.ToList();
		}


	}
}
