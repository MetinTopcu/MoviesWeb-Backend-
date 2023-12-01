using Movies.Services.Core.Application.CommonDtos;
using Movies.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Application.Dtos.Films
{
    public class FilmsCreateDto
    {
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int CategoriesId { get; set; }
        public Contents Contents { get; set; }
    }
}
