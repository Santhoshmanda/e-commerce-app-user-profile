using System;
using OGANI.UserService.Domain.Interfaces;
using OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Application
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;

        }
        public async Task<Address> CreateAddressAsync(Address address)
        {
            return await _addressRepository.CreateAddressAsync(address);
        }

        public async Task<bool> DeleteAddressAsync(int addressId)
        {
            return await _addressRepository.DeleteAddressAsync(addressId);
        }

        public async Task<Address?> GetAddressByIdAsync(int addressId)
        {
            return await _addressRepository.GetAddressByIdAsync(addressId);
        }

        public async Task<IEnumerable<Address>> GetAddressByUserIdAsync(int userId)
        {
            return await _addressRepository.GetAddressByUserIdAsync(userId);
        }

        public async Task UpdateAddressAsync(Address address)
        {
             await _addressRepository.UpdateAddressAsync(address);
        }
    }
}

