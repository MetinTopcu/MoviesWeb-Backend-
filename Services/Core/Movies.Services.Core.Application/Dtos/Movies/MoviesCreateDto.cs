﻿using Movies.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Application.Dtos.Movies
{
    public class MoviesCreateDto
    {
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; } // bölüm
        public int CategoriesId { get; set; }
        public List<Contents> Contents { get; set; }
    }
}
