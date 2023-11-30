using Movies.Services.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Domain.Entities
{
    public class Movies : GeneralEntity, IAggregateRoot
    {
        public int Season { get; set; }
        public int Episode { get; set; } // bölüm
    }
}
