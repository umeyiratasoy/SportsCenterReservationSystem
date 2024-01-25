using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstroturfImagesController : ControllerBase
    {
        IAstroturfImageService _astroturfImageService;


        public AstroturfImagesController(IAstroturfImageService astroturfImageService)
        {
            _astroturfImageService = astroturfImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()

        {
            var result = _astroturfImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int astroturfImage)
        {
            var result = _astroturfImageService.GetById(astroturfImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int astroturfImage)
        {
            var result = _astroturfImageService.GetCarImagesByCarId(astroturfImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] List<IFormFile> formFile, [FromForm] AstroturfImage astroturfImage)
        {

            var result = _astroturfImageService.Add(formFile, astroturfImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] AstroturfImage astroturfImage)
        {
            var result = _astroturfImageService.Delete(astroturfImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] List<IFormFile> file, [FromForm] AstroturfImage astroturfImage)
        {
            var result = _astroturfImageService.Update(file, astroturfImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}