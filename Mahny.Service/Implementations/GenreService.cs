using AutoMapper;
using Mahny.Core.Entities;
using Mahny.Data.Repositories.Interfaces;
using Mahny.Service.Dtos;
using Mahny.Service.Exceptions;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mahny.Service.Dtos.GenreDtos.Admin;

namespace Mahny.Service.Implementations
{
    public class GenreService : IGenreService
    {
        private IMapper _mapper;
        private IGenreRepository _repository;

        public GenreService(IMapper mapper, IGenreRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<GenreGetDto> GetAll()
        {
            return _mapper.Map<List<GenreGetDto>>(_repository.GetAll(x => !x.IsDeleted).ToList());
        }
        public PaginatedList<GenreListItemGetDto> GetPaginated(string? search = null, int page = 1, int size = 10)
        {
            var query = _repository.GetAll(x => !x.IsDeleted && (search == null || x.Name.Contains(search)));
            var paginated = PaginatedList<Genre>.Create(query, page, size);
            return new PaginatedList<GenreListItemGetDto>(_mapper.Map<List<GenreListItemGetDto>>(paginated.Items), paginated.TotalPages, page, size);
        }

        public int Create(GenreCreateDto createDto)
        {
            if (_repository.Exists(x => x.Name == createDto.Name && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Genre already exists");


            Genre entity = _mapper.Map<Genre>(createDto);
            _repository.Add(entity);
            _repository.Save();
            return entity.Id;
        }


        public GenreGetDto GetById(int id)
        {
            Genre entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Genre not found");

            return _mapper.Map<GenreGetDto>(entity);
        }

        public void Delete(int id)
        {

            Genre entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Genre not found");

            entity.IsDeleted = true;
            entity.ModifiedAt = DateTime.Now;
            _repository.Save();
        }

        public void Update(int id, GenreCreateDto dto)
        {
            Genre entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (_repository.Exists(x => x.Name == dto.Name && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Genre already exists");
            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Genre not found");

            entity.Name = dto.Name;
            entity.ModifiedAt = DateTime.Now;

            _repository.Save();
        }
    }
}
