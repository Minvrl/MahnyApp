using Mahny.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mahny.Service.Dtos.SliderDtos.Admin;

namespace Mahny.Service.Interfaces
{
    public interface ISliderService
    {
        //Admin
        List<SliderGetDto> GetAll();
        PaginatedList<SliderListItemGetDto> GetPaginated(string? search = null, int page = 1, int size = 5);
        int Create(SliderCreateDto createDto);
        SliderGetDto GetById(int id);
        void Delete(int id);
        void Update(int id, SliderUpdateDto updateDto);
    }
}
