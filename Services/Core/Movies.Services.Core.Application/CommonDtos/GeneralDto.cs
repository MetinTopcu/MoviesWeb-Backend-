using Movies.Services.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Application.CommonDtos
{
    public abstract class GeneralDto
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
