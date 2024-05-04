using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OGANI.UserService.Domain.Interfaces;
using OGANI.UserService.Domain.Models;
using OGANI.UserService.Infrastructure.Persistance;
using db_entities = OGANI.UserService.Infrastructure.Entities;

namespace OGANI.UserService.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly OganiDbContext _oganiDbContext;
        private readonly IMapper _mapper;

        public AddressRepository(OganiDbContext oganiDbContext, IMapper mapper)
        {
            _oganiDbContext = oganiDbContext;
            _mapper = mapper;
        }
		

        public async Task<Address> CreateAddressAsync(Address address)
        {
            var addressEntity = _mapper.Map<db_entities.Address>(address);
            _oganiDbContext.Addresses.Add(addressEntity);
            await _oganiDbContext.SaveChangesAsync();
            address.AddressId = addressEntity.AddressId;
            return address;
        }

        public async Task<bool> DeleteAddressAsync(int addressId)
        {
            var address = await _oganiDbContext.Addresses.FindAsync(addressId);
            if (address != null)
            {
                _oganiDbContext.Addresses.Remove(address);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<Address?> GetAddressByIdAsync(int addressId)
        {
            return await _oganiDbContext.Addresses
                .ProjectTo<Address>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(address=>address.AddressId==addressId);
        }

        public async Task<IEnumerable<Address>> GetAddressByUserIdAsync(int userId)
        {
            return await _oganiDbContext.Addresses
                .ProjectTo<Address>(_mapper.ConfigurationProvider)
                .Where(address => address.UserId == userId).ToListAsync();
        }

        public async Task UpdateAddressAsync(Address address)
        {
            var addressEntity = _mapper.Map<db_entities.Address>(address);
            _oganiDbContext.Entry(addressEntity).State = EntityState.Modified;
            await _oganiDbContext.SaveChangesAsync();
        }
    }
}

