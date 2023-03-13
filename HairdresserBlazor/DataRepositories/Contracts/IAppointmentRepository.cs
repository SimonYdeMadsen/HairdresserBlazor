using HairdresserBlazor.Entities;

namespace HairdresserBlazor.DataRepositories.Contracts
{
    public interface IAppointmentRepository
    {
		Task<IEnumerable<Appointment>> GetHairdresserAppointments(int hairdresserId);
		Task AddAppointment(int userId, int hairdresserId, DateTime startTime, DateTime endTime);
        Task<Appointment> GetAppointment(int appointmentId);
		Task<IEnumerable<Appointment>> GetWeeklyAppointments(DateTime date);
		Task<List<Appointment>> GetWeeklyHairdresserAppointments(DateTime date, int hairdresserId);

	}
}