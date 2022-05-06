using Business.Automapper.Profiles;
using Business.BusinessRules.GenericBusinessRules.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiraProject.Helper;
using Shared.Dto;
using Shared.Helpers;

namespace MiraProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : CustomBaseController
    {
        private readonly IGenericBusinessRules<ModuleDto, ModuleProfile> _genericBusinessRules;
        public ModuleController(IGenericBusinessRules<ModuleDto, ModuleProfile> genericBusinessRules)
        {
            _genericBusinessRules = genericBusinessRules;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ModuleDto moduleDto)
        {
            if (moduleDto == null)
            {
                return ActionResultInstance(Response<ModuleDto>.Fail("Module is null", 404, true));
            }

            List<string> uniqueColumns = new List<string>()
            {
            "Name"
            };

            List<object> uniqueValues = new List<object>()
            {
                moduleDto.Name,
            };
            moduleDto.IsActive = true;
            moduleDto.IsDeleted = false;
            return ActionResultInstance(await _genericBusinessRules.Insert(moduleDto, uniqueColumns, uniqueValues));
        }
    }
}
