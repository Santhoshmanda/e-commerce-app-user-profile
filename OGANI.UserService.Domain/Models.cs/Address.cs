using System.ComponentModel.DataAnnotations;

namespace OGANI.UserService.Domain.Models;

public partial class Address
{
    public int AddressId { get; set; }

    [Required(ErrorMessage = "UserId is required")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Street is required")]
    [MaxLength(50, ErrorMessage = "Street cannot exceed 50 characters")]
    public string Street { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [MaxLength(50, ErrorMessage = "City cannot exceed 50 characters")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "State is required")]
    [MaxLength(50, ErrorMessage = "State cannot exceed 50 characters")]
    public string State { get; set; } = null!;

    [Required(ErrorMessage = "Zipcode is required")]
    [MaxLength(50, ErrorMessage = "Zipcode cannot exceed 50 characters")]
    public string Zipcode { get; set; } = null!;

    [Required(ErrorMessage = "IsShippingAddress is required")]
    public bool IsShippingAddress { get; set; }

    //public virtual UserProfile User { get; set; } = null!;
}
