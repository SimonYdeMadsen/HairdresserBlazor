using BlazorDbAccess.Entities;

namespace BlazorDbAccess.DataRepositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<Appointment>> GetUserAppointments(int userId);
    }
}