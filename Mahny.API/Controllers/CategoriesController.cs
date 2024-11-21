using Mahny.Service.Dtos.CategoryDtos.Admin;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahny.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Categories")] 
        public ActionResult<List<CategoryGetDto>> GetAll()
        {
            return Ok(_categoryService.GetAll());
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Categories/Paginated")]
        public ActionResult<List<CategoryListItemGetDto>> GetAllPaginated(string? search = null, int page = 1, int size = 10)
        {
            return Ok(_categoryService.GetPaginated(search, page, size));
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpPost("admin/Categories")] 
        public ActionResult Create(CategoryCreateDto createDto)
        {
            return StatusCode(201, new {Id =_categoryService.Create(createDto) });
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Categories/{id}")]
        public ActionResult GetById(int id)
        {
            return StatusCode(200, _categoryService.GetById(id));
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpDelete("admin/Categories/{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent(); 
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpPut("admin/Categories/{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] CategoryCreateDto dto)
        {
            _categoryService.Update(id, dto);
            return NoContent();
        }

    }
}
