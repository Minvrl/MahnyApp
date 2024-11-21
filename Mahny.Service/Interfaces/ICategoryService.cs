using Mahny.Service.Dtos;
using Mahny.Service.Dtos.CategoryDtos.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Service.Interfaces
{
    public interface ICategoryService
    {
        //Admin
        List<CategoryGetDto> GetAll();
        PaginatedList<CategoryListItemGetDto> GetPaginated(string? search = null, int page = 1, int size = 10);
        int Create(CategoryCreateDto createDto);
        CategoryGetDto GetById(int id);
        void Delete(int id);    
        void Update(int id, CategoryCreateDto updateDto);
    }
}
