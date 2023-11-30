using AutoMapper;
using Movies.Services.Core.Application.Dtos;
using Movies.Services.Core.Application.Dtos.Films;
using Movies.Services.Core.Application.Dtos.Movies;
using Movies.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Application.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Films, FilmsDto>().ReverseMap();
            CreateMap<Movie, MoviesDto>().ReverseMap();
            CreateMap<Contents, ContentsDto>().ReverseMap();
            CreateMap<Categories, CategoriesDto>().ReverseMap();

            CreateMap<Films, FilmsCreateDto>().ReverseMap();
            CreateMap<Films, FilmsUpdateDto>().ReverseMap();

            CreateMap<Movie, MoviesCreateDto>().ReverseMap();
            CreateMap<Movie, MoviesUpdateDto>().ReverseMap();

        }
    }
}
