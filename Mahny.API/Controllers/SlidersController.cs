using Mahny.Service.Dtos.SliderDtos.Admin;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahny.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private ISliderService _sliderService;

        public SlidersController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
       
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Sliders")]
        public ActionResult<List<SliderGetDto>> GetAll()
        {
            return Ok(_sliderService.GetAll());
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Sliders/Paginated")]
        public ActionResult<List<SliderListItemGetDto>> GetAllPaginated(string? search = null, int page = 1, int size = 5)
        {
            return Ok(_sliderService.GetPaginated(search, page, size));
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpPost("admin/Sliders")]
        public ActionResult Create(SliderCreateDto createDto)
        {
            return StatusCode(201, new { Id = _sliderService.Create(createDto) });
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpGet("admin/Sliders/{id}")]
        public ActionResult<SliderGetDto> GetById(int id)
        {
            return StatusCode(200, _sliderService.GetById(id));
        }
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpDelete("admin/Sliders/{id}")]
        public ActionResult Delete(int id)
        {
            _sliderService.Delete(id);
            return NoContent();
        }
      
        [ApiExplorerSettings(GroupName = "admin_v1")]
        [HttpPut("admin/Sliders/{id}")]
        public ActionResult Update([FromRoute] int id, [FromForm] SliderUpdateDto updateDto)
        {
            _sliderService.Update(id, updateDto);
            return NoContent();
        }
       
    }
}
