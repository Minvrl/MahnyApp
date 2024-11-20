using Mahny.Service.Dtos.CategoryDtos.Admin;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahny.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public ActionResult<List<CategoryGetDto>> GetAll()
        {
            return Ok(_categoryService.GetAll());
        }
        [HttpPost("")]
        public ActionResult Create(CategoryCreateDto createDto)
        {
            return StatusCode(201, new {Id =_categoryService.Create(createDto) });
        }



    }
}
