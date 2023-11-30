using Movies.Services.Core.Application.CommonDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Application.Dtos.Films
{
    public class FilmsDto : GeneralDto
    {
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int CategoriesId { get; set; }
        public CategoriesDto Categories { get; set; }
        public List<ContentsDto> Contents { get; set; }
    }
}
