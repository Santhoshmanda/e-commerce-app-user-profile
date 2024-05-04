using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OGANI.UserService.Domain.Models;
using db_entities=OGANI.UserService.Infrastructure.Entities;
using OGANI.UserService.Infrastructure.Persistance;
using AutoMapper.QueryableExtensions;
using OGANI.UserService.Domain.Interfaces;

namespace OGANI.UserService.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly OganiDbContext _oganiDbContext;
        private readonly IMapper _mapper;

        public UserProfileRepository(OganiDbContext oganiDbContext, IMapper mapper)
		{
            _oganiDbContext = oganiDbContext;
            _mapper = mapper;
        }

        public async Task<UserProfile> CreateUserAsync(UserProfile userProfile)
        {
            var userProfileEntity = _mapper.Map<db_entities.UserProfile>(userProfile);
            _oganiDbContext.UserProfiles.Add(userProfileEntity);
            await _oganiDbContext.SaveChangesAsync();
            userProfile.UserId = userProfileEntity.UserId;
            return userProfile;
        }

        public async Task<UserProfile?> GetUserByAdObjAsync(string adObj)
        {
            return await _oganiDbContext.UserProfiles
                .ProjectTo<UserProfile>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(user=>user.AdObjId==adObj);
        }

        public async Task<UserProfile?> GetUserByIdAsync(int userId)
        {
            return await _oganiDbContext.UserProfiles
                .ProjectTo<UserProfile>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(user=>user.UserId==userId);
        }

        public async Task<IEnumerable<UserProfile>> GetUsersAsync()
        {
            return await _oganiDbContext.UserProfiles
                .ProjectTo<UserProfile>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateUserAsync(UserProfile userProfile)
        {
            _oganiDbContext.Entry(userProfile).State = EntityState.Modified;
            await _oganiDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userProfile = await _oganiDbContext.UserProfiles.FindAsync(userId);
            if (userProfile != null)
            {
                _oganiDbContext.UserProfiles.Remove(userProfile);
                await _oganiDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

