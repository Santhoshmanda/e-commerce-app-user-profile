using System.ComponentModel.DataAnnotations;

namespace OGANI.UserService.Domain.Models;

public partial class UserRole
{
   
    public int UserRoleId { get; set; }

    [Required(ErrorMessage ="UserId is required")]
    public int UserId { get; set; }

    [Required(ErrorMessage ="RoleId is required")]
    public int RoleId { get; set; }

    //public virtual Role Role { get; set; } = null!;

    //public virtual UserProfile User { get; set; } = null!;
}
