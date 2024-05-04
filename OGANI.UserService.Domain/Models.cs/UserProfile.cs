using System.ComponentModel.DataAnnotations;

namespace OGANI.UserService.Domain.Models;

public partial class UserProfile
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "DisplayName is required")]
    [MaxLength(100, ErrorMessage = "DisplayName cannot exceed 100 characters")]
    public string DisplayName { get; set; } = null!;

    [Required(ErrorMessage = "FirstName is required")]
    [MaxLength(100,ErrorMessage = "FirstName cannot exceed 100 characters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "LastName is required")]
    [MaxLength(100, ErrorMessage = "LastName cannot exceed 100 characters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "EmailId is required")]
    [MaxLength(100, ErrorMessage = "EmailId cannot exceed 100 characters")]
    public string EmailId { get; set; } = null!;

    [Required(ErrorMessage = "AdObjId is required")]
    [MaxLength(100, ErrorMessage = "AdObjId cannot exceed 100 characters")]
    public string AdObjId { get; set; } = null!;

    //public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    //public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
