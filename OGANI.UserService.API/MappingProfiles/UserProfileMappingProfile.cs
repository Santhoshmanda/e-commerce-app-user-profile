using AutoMapper;
using OGANI.UserService.API.Dto;
using OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Infrastructure.MappingProfiles
{
    public class UserProfileMappingProfile : Profile
	{
		public UserProfileMappingProfile()
		{
            CreateMap<UserProfileDto, UserProfile>();
        }
	}
}

