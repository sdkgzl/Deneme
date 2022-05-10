using Business.BusinessRules.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiraProject.Helper;
using Shared.Authorization;
using Shared.Dto;

namespace MiraProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : CustomBaseController
    {
        private readonly IUserBusinessRules _userBusinessRules;
        public UserController(IUserBusinessRules userBusinessRules)
        {
            _userBusinessRules = userBusinessRules;
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _userBusinessRules.GetAll());
        }
        
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            return ActionResultInstance(await _userBusinessRules.Update(userDto));
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UpdatePasswordDto updatePasswordDto)
        {
            return ActionResultInstance(await _userBusinessRules.ChangePassword(updatePasswordDto));
        }
    }
}
