using AutoMapper;
using Mahny.Core.Entities;
using Mahny.Data.Repositories.Interfaces;
using Mahny.Service.Dtos;
using Mahny.Service.Dtos.CategoryDtos.Admin;
using Mahny.Service.Exceptions;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private IMapper _mapper;
        private ICategoryRepository _repository;
        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public List<CategoryGetDto> GetAll()
        {
            return _mapper.Map<List<CategoryGetDto>>(_repository.GetAll(x => !x.IsDeleted).ToList());
        }
        public PaginatedList<CategoryListItemGetDto> GetPaginated(string? search = null, int page = 1, int size = 10)
        {
            var query = _repository.GetAll(x => !x.IsDeleted && (search == null || x.Name.Contains(search)));
            var paginated = PaginatedList<Category>.Create(query, page, size);
            return new PaginatedList<CategoryListItemGetDto>(_mapper.Map<List<CategoryListItemGetDto>>(paginated.Items),paginated.TotalPages,page,size);
        }

        public int Create(CategoryCreateDto createDto)
        {
            if (_repository.Exists(x => x.Name == createDto.Name && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Category already exists");


            Category entity = _mapper.Map<Category>(createDto);
            _repository.Add(entity);
            _repository.Save();
            return entity.Id;
        }

      
        public CategoryGetDto GetById(int id)
        {
            Category entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Category not found");

            return _mapper.Map<CategoryGetDto>(entity);
        }

        public void Delete(int id)
        {

            Category entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Category not found");

            entity.IsDeleted = true;
            entity.ModifiedAt = DateTime.Now;
            _repository.Save();
        }

        public void Update(int id, CategoryCreateDto dto)
        {
            Category entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (_repository.Exists(x => x.Name == dto.Name && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Category already exists");
            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Category not found");

            entity.Name = dto.Name;
            entity.ModifiedAt = DateTime.Now;

            _repository.Save();
        }
    }
}
