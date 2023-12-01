using Movies.Services.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Domain.Entities
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Films> Films { get; set; }

        public ICollection<Movie> Movie { get; set; }

    }
}
