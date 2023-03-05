using HairdresserBlazor.Entities;

namespace HairdresserBlazor.DataRepositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUsers();
        Task<ICollection<Appointment>> GetUserAppointments(int userId);
    }
}