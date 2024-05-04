using OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Domain.Interfaces
{
	public interface IAddressService
	{
		Task<IEnumerable<Address>> GetAddressByUserIdAsync(int userId);
		Task<Address?> GetAddressByIdAsync(int addressId);
		Task<Address> CreateAddressAsync(Address address);
		Task UpdateAddressAsync(Address address);
        Task<bool> DeleteAddressAsync(int addressId);
    }
}

