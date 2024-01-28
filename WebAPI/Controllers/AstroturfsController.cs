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

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _astroturfService.GetById(id);
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


        [HttpGet("getastroturfsbycitydistrict")]
        public IActionResult GetAstroturfsByCityDistrict(int fieldId, int cityId, int districtsId)
        {
            var result = _astroturfService.GetAstroturfsByCityDistrict(fieldId, cityId, districtsId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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


        [HttpPost("delete")]
        public IActionResult Delete(Astroturf astroturf)
        {
            var result = _astroturfService.Delete(astroturf);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("update")]
        public IActionResult Update(Astroturf astroturf)
        {
            var result = _astroturfService.Update(astroturf);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
