using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkQuete2
{
    static class Program
    {
        static void Main()
        {
            using (var context = new SpeciesContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var species1 = new Species
                {
                    Name = "Cougars",
                    AnimalList = GenerateSpecies("WhiteCougars", 3)
                };

                var species2 = new Species
                {
                    Name = "Tigers",
                    AnimalList = GenerateSpecies("WhiteTigers", 100)
                };

                var species3 = new Species
                {
                    Name = "Turtles",
                    AnimalList = GenerateSpecies("AlbinosTurtles", 15)
                };

                context.Add(species1);
                context.Add(species2);
                context.Add(species3);
                context.SaveChanges();

                var speciesCount = from anim in context.Animal.AsEnumerable()
                                   group anim by anim.Species into animalGroup
                                   select animalGroup;

                String message = String.Empty;
                foreach (var group in speciesCount)
                {
                    message += group.Key + ": " + group.Count() + "\n";
                }
                MessageBox.Show(message);
            }
        }

        static List<Animal> GenerateSpecies(string speciesName, int animalCount)
        {
            var species = new Species();
            species.Name = speciesName;
            List<Animal> speciesAnimal = new List<Animal>();
            for (int i=0; i<animalCount; i ++)
            {
                var newAnimal = new Animal();
                newAnimal.Name = species.Name + i;
                speciesAnimal.Add(newAnimal);
            }
            species.AnimalList = speciesAnimal;
            return species.AnimalList;
        }
    }
}
