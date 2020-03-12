using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkQuete2
{
    class Species
    {
        public Guid SpeciesId { get; set; }
        public string Name { get; set; }
        public List<Animal> AnimalList { get; set; }
    }
}
