using Mahny.Service.Dtos.GenreDtos.Admin;
using Mahny.Service.Implementations;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahny.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Genres")]
        public ActionResult<List<GenreGetDto>> GetAll()
        {
            return Ok(_genreService.GetAll());
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Genres/Paginated")]
        public ActionResult<List<GenreListItemGetDto>> GetAllPaginated(string? search = null, int page = 1, int size = 10)
        {
            return Ok(_genreService.GetPaginated(search, page, size));
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpPost("admin/Genres")]
        public ActionResult Create(GenreCreateDto createDto)
        {
            return StatusCode(201, new { Id = _genreService.Create(createDto) });
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Genres/{id}")]
        public ActionResult GetById(int id)
        {
            return StatusCode(200, _genreService.GetById(id));
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpDelete("admin/Genres/{id}")]
        public ActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return NoContent();
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpPut("admin/Genres/{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] GenreCreateDto dto)
        {
            _genreService.Update(id, dto);
            return NoContent();
        }
    }
}
