using HairdresserBlazor.Data;
using HairdresserBlazor.DataRepositories.Contracts;
using HairdresserBlazor.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairdresserBlazor.DataRepositories
{
	public class HairdresserRepository : IHairdresserRepository
	{

		private readonly IDbContextFactory<SalonDbContext> DbFactory;

		public HairdresserRepository(IDbContextFactory<SalonDbContext> dbFactory)
		{
			this.DbFactory = dbFactory;
		}

		public async Task<IEnumerable<Hairdresser>> GetHairdressers()
		{
			using var dbContext = DbFactory.CreateDbContext();

			return await dbContext.Hairdressers
				.ToListAsync();
		}

		public async Task<IEnumerable<int>> GetHairdresserIds()
		{

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

		public async Task<IEnumerable<string>> GetHairdresserNames(IEnumerable<int> hairdresserIds)
		{
			using var dbContext = DbFactory.CreateDbContext();
			return await dbContext.Hairdressers.Select(h => h.UserName).ToListAsync();
		}

	}
}
