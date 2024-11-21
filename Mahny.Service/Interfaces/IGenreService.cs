using Mahny.Service.Dtos.CategoryDtos.Admin;
using Mahny.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mahny.Service.Dtos.GenreDtos.Admin;

namespace Mahny.Service.Interfaces
{
    public interface IGenreService
    {
        //Admin
        List<GenreGetDto> GetAll();
        PaginatedList<GenreListItemGetDto> GetPaginated(string? search = null, int page = 1, int size = 10);
        int Create(GenreCreateDto createDto);
        GenreGetDto GetById(int id);
        void Delete(int id);
        void Update(int id, GenreCreateDto updateDto);
    }
}
