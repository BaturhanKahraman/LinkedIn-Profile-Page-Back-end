using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        [HttpPost("Add")]
        public IActionResult Add(Experience exp)
        {
            var result = _experienceService.Add(exp);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(Experience exp)
        {
            var result = _experienceService.Update(exp);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Experience exp)
        {
            var result = _experienceService.Delete(exp);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
