using OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Domain.Interfaces
{
    public interface IRoleService
	{
        Task<Role> CreateRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task<bool> DeleteRole(int roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetUserRole(int userId);
        Task<UserRole> AssignRole(int userId, string roleName);
    }
}

