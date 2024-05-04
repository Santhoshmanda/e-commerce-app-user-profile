using System;
namespace OGANI.UserService.API.Dto
{
	public class UserProfileDto
	{
        public string DisplayName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailId { get; set; } = null!;

        public string AdObjId { get; set; } = null!;
    }
}

