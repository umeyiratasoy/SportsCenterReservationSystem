using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstroturfsController : ControllerBase
    {
        private IAstroturfService _astroturfService;

        public AstroturfsController(IAstroturfService astroturfService)
        {
            _astroturfService = astroturfService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _astroturfService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message); 
        }

        [HttpGet("getastroturflist")]
        public IActionResult GetAstroturfList()
        {
            var result = _astroturfService.GetAstroturfList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message); 
        }

        [HttpPost("add")]
        public IActionResult Add(Astroturf astroturf)
        {
            var result = _astroturfService.Add(astroturf);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
