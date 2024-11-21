using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mahny.Core.Entities;
using Mahny.Service.Dtos.CategoryDtos.Admin;
using Microsoft.AspNetCore.Http;
using Mahny.Service.Dtos.GenreDtos.Admin;
using Mahny.Service.Dtos.SliderDtos.Admin;

namespace Mahny.Service.Profiles
{
    public class MapProfile : Profile
    {
        private readonly IHttpContextAccessor _context;

        public MapProfile(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;
            var uriBuilder = new UriBuilder(_context.HttpContext.Request.Scheme, _context.HttpContext.Request.Host.Host, _context.HttpContext.Request.Host.Port ?? -1);
            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            string baseUrl = uriBuilder.Uri.AbsoluteUri;

            //Category
            CreateMap<Category, CategoryGetDto>();
            CreateMap<Category, CategoryListItemGetDto>();
            CreateMap<CategoryCreateDto, Category>();

            //Genre
            CreateMap<Genre, GenreGetDto>();
            CreateMap<Genre, GenreListItemGetDto>();
            CreateMap<GenreCreateDto, Genre>();

            //Slider
            CreateMap<Slider, SliderGetDto>()
                .ForMember(dest => dest.Image, s => s.MapFrom(s => baseUrl + "uploads/slider/" + s.Image));
            CreateMap<Slider, SliderListItemGetDto>()
                .ForMember(dest => dest.Image, s => s.MapFrom(s => baseUrl + "uploads/slider/" + s.Image));
            CreateMap<SliderCreateDto, Slider>();

        }
    }
}
