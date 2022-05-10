using Business.BusinessRules.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiraProject.Helper;
using Newtonsoft.Json;
using Shared.Authorization;
using Shared.Dto;

namespace MiraProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : CustomBaseController
    {
        private readonly IAuthBusinessRules _authBusinessRules;
        private readonly HttpClient _httpClient;
        public AuthController(IAuthBusinessRules authBusinessRules, HttpClient httpClient)
        {
            _authBusinessRules = authBusinessRules;
            _httpClient = httpClient;
        }

        [Route("api/[controller]/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            return ActionResultInstance(await _authBusinessRules.Register(request));
        }

        
        [Route("api/[controller]/login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateRequestDto request)
        {
            return ActionResultInstance(await _authBusinessRules.Authenticate(request));      
        }

        [Route("api/[controller]/getRockets")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRockets()
        {
            List<RocketDto> rocketDtos = new();
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "API_KEY_1");
            HttpResponseMessage res = await _httpClient.GetAsync("http://localhost:5000/rockets");
            if(res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string msg = await res.Content.ReadAsStringAsync();
                rocketDtos = JsonConvert.DeserializeObject<List<RocketDto>>(msg);
                return new JsonResult(rocketDtos);
            }

            return new JsonResult(res.StatusCode);                        
        }


    }
}
