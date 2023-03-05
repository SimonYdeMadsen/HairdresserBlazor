namespace HairdresserBlazor.Services
{
	public interface IUserHandler
	{
		Task<int> GetCurrentUserId();
	}
}