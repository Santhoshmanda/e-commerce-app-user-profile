using OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Domain.Interfaces;

public interface IUserProfileRepository
{
	    Task<UserProfile> CreateUserAsync(UserProfile userProfile);
        Task<UserProfile?> GetUserByIdAsync(int userId);
        Task<UserProfile?> GetUserByAdObjAsync(string adObj);
        Task<IEnumerable<UserProfile>> GetUsersAsync();
        Task UpdateUserAsync(UserProfile userProfile);
	    Task<bool> DeleteUserAsync(int userId);
}

