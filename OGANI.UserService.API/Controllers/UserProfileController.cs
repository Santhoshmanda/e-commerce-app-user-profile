using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OGANI.UserService.Domain.Interfaces;
using OGANI.UserService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.UserService.API.Controllers
{
    [Route("api/user-profiles")]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileService userProfileService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserProfile>> GetUserById(int userId)
        {
            var userProfile = await _userProfileService.GetUserByIdAsync(userId);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetAllsUsers()
        {
            var userProfile = await _userProfileService.GetUsersAsync();
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        [HttpPost]
        public async Task<ActionResult<UserProfile>> CreateUser([FromBody] UserProfile userProfile)
        {
            //var userProfileModel= _mapper.Map<UserProfile>(userProfileDto);
            var createdUserProfile = await _userProfileService.CreateUserAsync(userProfile);
            return CreatedAtAction(nameof(CreateUser), createdUserProfile);
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserProfile userProfile)
        {
            if (userId != userProfile.UserId)
            {
                return BadRequest("User ID in the request body does not match the URL parameter.");
            }

            await _userProfileService.UpdateUserAsync(userProfile);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var isSuccess = await _userProfileService.DeleteUserAsync(userId);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}

