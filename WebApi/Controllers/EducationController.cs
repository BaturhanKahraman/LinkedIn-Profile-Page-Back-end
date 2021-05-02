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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Education education)
        {
            var result = _educationService.Add(education);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Education education)
        {
            var result = _educationService.Update(education);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Education education)
        {
            var result = _educationService.Delete(education);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
