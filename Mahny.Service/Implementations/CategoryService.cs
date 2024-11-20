using AutoMapper;
using Mahny.Core.Entities;
using Mahny.Data.Repositories.Interfaces;
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

        public int Create(CategoryCreateDto createDto)
        {
            if (_repository.Exists(x => x.Name == createDto.Name && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Category already exists");


            Category entity = _mapper.Map<Category>(createDto);
            _repository.Add(entity);
            _repository.Save();
            return entity.Id;
        }

    }
}
