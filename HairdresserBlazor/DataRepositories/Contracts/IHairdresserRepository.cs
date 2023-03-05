using HairdresserBlazor.Entities;

namespace HairdresserBlazor.DataRepositories.Contracts
{
    public interface IHairdresserRepository
    {
        Task<Hairdresser> GetHairdresser(int hairdresserId);
        Task<IEnumerable<Hairdresser>> GetHairdressers();
        Task<IEnumerable<int>> GetHairdresserIds();
    }
}