using Business.BusinessRules.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiraProject.Helper;
using Shared.Dto;

namespace MiraProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : CustomBaseController
    {
        private readonly IAuthBusinessRules _authBusinessRules;
        public AuthController(IAuthBusinessRules authBusinessRules)
        {
            _authBusinessRules = authBusinessRules;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            return ActionResultInstance(await _authBusinessRules.Register(request));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateRequestDto request)
        {
            return ActionResultInstance(await _authBusinessRules.Authenticate(request));            
        }


        [HttpPost("deneme")]
        public async Task<IActionResult> Sadik(AuthenticateRequestDto request)
        {
            return ActionResultInstance(await _authBusinessRules.Authenticate(request));
        }


    }
}
