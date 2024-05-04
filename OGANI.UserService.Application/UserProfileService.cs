using System;
using OGANI.UserService.Domain.Interfaces;
using OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Application
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<UserProfile> CreateUserAsync(UserProfile userProfile) =>
            await _userProfileRepository.CreateUserAsync(userProfile);


        public async Task<bool> DeleteUserAsync(int userId) =>
            await _userProfileRepository.DeleteUserAsync(userId);


        public async Task<UserProfile?> GetUserByAdObjAsync(string adObj) =>
            await _userProfileRepository.GetUserByAdObjAsync(adObj);


        public async Task<UserProfile?> GetUserByIdAsync(int userId) =>
            await _userProfileRepository.GetUserByIdAsync(userId);

        public async Task<IEnumerable<UserProfile>> GetUsersAsync() =>
            await _userProfileRepository.GetUsersAsync();


        public async Task UpdateUserAsync(UserProfile userProfile) =>
            await _userProfileRepository.UpdateUserAsync(userProfile);
    }
}

