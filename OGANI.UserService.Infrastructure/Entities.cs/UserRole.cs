using System;
using System.Collections.Generic;

namespace OGANI.UserService.Infrastructure.Entities;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual UserProfile User { get; set; } = null!;
}
