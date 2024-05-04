using AutoMapper;
using OGANI.UserService.Infrastructure.Entities;
using Model = OGANI.UserService.Domain.Models;

namespace OGANI.UserService.Infrastructure.MappingProfiles
{
    public class UserProfileMappingProfile : Profile
	{
		public UserProfileMappingProfile()
		{
			CreateMap<UserProfile,Model.UserProfile>();
            CreateMap<Model.UserProfile, UserProfile>();
            CreateMap<Address, Model.Address>();
            CreateMap<Model.Address, Address>();
        }
	}
}

