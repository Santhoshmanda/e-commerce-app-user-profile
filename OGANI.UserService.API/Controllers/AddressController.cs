using Microsoft.AspNetCore.Mvc;
using OGANI.UserService.Domain.Interfaces;
using OGANI.UserService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OGANI.UserService.API.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        //private readonly IMapper _mapper;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
            //_mapper = mapper;
        }

        [HttpGet("{addressId}")]
        public async Task<ActionResult<Address>> GetAddressById(int addressId)
        {
            var address = await _addressService.GetAddressByIdAsync(addressId);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpGet("user/{userId}")] //later take the userId from claims
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressByUserId(int userId)
        {
            var address = await _addressService.GetAddressByUserIdAsync(userId);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserProfile>>> GetAllsUsers()
        //{
        //    var userProfile = await _userProfileService.GetUsersAsync();
        //    if (userProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userProfile);
        //}

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
        {
            //var userProfileModel= _mapper.Map<UserProfile>(userProfileDto);
            //take userId from claims in future
            var createdUserProfile = await _addressService.CreateAddressAsync(address);
            return CreatedAtAction(nameof(CreateAddress), createdUserProfile);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            await _addressService.UpdateAddressAsync(address);
            return NoContent();
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            var isSuccess = await _addressService.DeleteAddressAsync(addressId);
            if (!isSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

