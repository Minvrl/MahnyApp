using AutoMapper;
using Mahny.Core.Entities;
using Mahny.Data;
using Mahny.Data.Repositories.Interfaces;
using Mahny.Service.Dtos;
using Mahny.Service.Dtos.SliderDtos.Admin;
using Mahny.Service.Exceptions;
using Mahny.Service.Extensions;
using Mahny.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Service.Implementations
{
    public class SliderService:ISliderService
    {
        private IMapper _mapper;
        private ISliderRepository _repository;
        private readonly AppDbContext _context;

        public SliderService(IMapper mapper, ISliderRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;

        }

        public List<SliderGetDto> GetAll()
        {
            return _mapper.Map<List<SliderGetDto>>(_repository.GetAll(x => !x.IsDeleted).ToList());
        }

        public PaginatedList<SliderListItemGetDto> GetPaginated(string? search = null, int page = 1, int size = 5)
        {
            var query = _repository.GetAll(x=> !x.IsDeleted && (search ==  null || x.PrimaryText.Contains(search)));
            var paginated = PaginatedList<Slider>.Create(query, page, size);
            return new PaginatedList<SliderListItemGetDto>(_mapper.Map<List<SliderListItemGetDto>>(paginated.Items),paginated.TotalPages, page, size);
        }

        public int Create(SliderCreateDto createDto)
        {
            if(_repository.Exists(x=> x.Order == createDto.Order && !x.IsDeleted))
                throw new RestException(StatusCodes.Status400BadRequest, "Order","Add another order !");

         
            Slider entity = _mapper.Map<Slider>(createDto);
            entity.Image = createDto.File.Save("uploads/slider");
            _repository.Add(entity);
            _repository.Save();
            return entity.Id;
          
        }

        public SliderGetDto GetById(int id)
        {
            Slider entity = _repository.Get(x => x.Id == id && !x.IsDeleted);

            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Slider not found by given id");

            return _mapper.Map<SliderGetDto>(entity);
        }

        public void Delete(int id)
        {
            Slider entity = _repository.Get(x => x.Id == id && !x.IsDeleted);
            if (entity == null) throw new RestException(StatusCodes.Status404NotFound, "Slider not found!");

            entity.Image.Delete("uploads/slider");

            entity.IsDeleted = true;
            entity.ModifiedAt = DateTime.Now;

            _repository.Save();
        }

        public void Update(int id, SliderUpdateDto updateDto)
        {
            Slider entity = _repository.Get(x => x.Id == id && !x.IsDeleted);
            if (entity == null)
                throw new RestException(StatusCodes.Status404NotFound, "Slider not found");

            entity.PrimaryText = updateDto.PrimaryText;
            entity.Order = updateDto.Order;
            entity.SecondaryText= updateDto.SecondaryText;


            if (updateDto.File != null)
            {
                entity.Image.Delete("uploads/slider");

                entity.Image = updateDto.File.Save("uploads/slider");
            }

            _context.SaveChanges();
        }
    }
}
