using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkQuete2
{
    class Animal
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; }
        public int AnimalQuantity { get; set; }
        public Species Species { get; set; }
    }
}
