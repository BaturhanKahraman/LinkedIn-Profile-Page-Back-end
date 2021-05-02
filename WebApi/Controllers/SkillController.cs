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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillController(ISkillService service)
        {
            _service = service;
        }

        [HttpPost("SaveRange")]
        public IActionResult SaveRange(List<Skill> skills)
        {
            var result = _service.AddRange(skills);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
