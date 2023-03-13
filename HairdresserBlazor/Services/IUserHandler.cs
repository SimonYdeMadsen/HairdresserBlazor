namespace HairdresserBlazor.Services
{
	public interface IUserHandler
	{
		Task<int> GetCurrentUserId();

		Task<int> CreateUserAsync(string userName);
	}
}