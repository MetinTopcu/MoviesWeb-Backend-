using Movies.Services.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Domain.Entities
{
    public class Movie : GeneralEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; } // bölüm
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public List<Contents> Contents { get; set; }
    }
}
