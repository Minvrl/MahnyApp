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
        List<CategoryGetDto> GetAll();
        int Create(CategoryCreateDto createDto);
    }
}
