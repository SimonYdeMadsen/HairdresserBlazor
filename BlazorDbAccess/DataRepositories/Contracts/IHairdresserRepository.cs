using BlazorDbAccess.Entities;

namespace BlazorDbAccess.DataRepositories.Contracts
{
    public interface IHairdresserRepository
    {
        Task<Hairdresser> GetHairdresser(int hairdresserId);
        Task<IEnumerable<Hairdresser>> GetHairdressers();
        Task<IEnumerable<int>> GetHairdresserIds();
    }
}