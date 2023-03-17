using System.Security.Claims;

namespace HairdresserBlazor.Services
{
	public interface IUserHandler
	{
        Task<ClaimsPrincipal> GetCurrentUser();

        int GetId(ClaimsPrincipal user);

        Task<int> CreateUser(string userName);
	}
}