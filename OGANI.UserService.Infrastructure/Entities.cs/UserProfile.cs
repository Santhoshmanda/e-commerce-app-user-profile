using System;
using System.Collections.Generic;

namespace OGANI.UserService.Infrastructure.Entities;

public partial class UserProfile
{
    public int UserId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string AdObjId { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
