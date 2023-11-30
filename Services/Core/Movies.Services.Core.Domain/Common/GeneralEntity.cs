using Movies.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Core.Domain.Common
{
    public abstract class GeneralEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
