using HairdresserBlazor.Data;
using HairdresserBlazor.DataRepositories.Contracts;
using HairdresserBlazor.Entities;
using Microsoft.EntityFrameworkCore;

namespace HairdresserBlazor.DataRepositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IDbContextFactory<SalonDbContext> DbFactory;

		public UserRepository(IDbContextFactory<SalonDbContext> dbFactory)
		{
			this.DbFactory = dbFactory;
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
	}
}
