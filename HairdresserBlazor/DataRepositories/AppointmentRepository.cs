using HairdresserBlazor.Data;
using HairdresserBlazor.DataRepositories.Contracts;
using HairdresserBlazor.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using HairdresserBlazor.Utility;

namespace HairdresserBlazor.DataRepositories
{
    public class AppointmentRepository : IAppointmentRepository
	{

		private readonly IDbContextFactory<SalonDbContext> DbFactory;

		public AppointmentRepository(IDbContextFactory<SalonDbContext> dbFactory)
		{
			this.DbFactory = dbFactory;
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
			return userAppointments;
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
