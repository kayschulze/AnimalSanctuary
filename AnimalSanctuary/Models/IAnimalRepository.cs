using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSanctuary.Models
{
    public class IAnimalRepository
    {
        IQueryable<Animal> Animals { get; }
        Animal Save(Animal animal);
        Animal Edit(Animal animal);
        void Remove(Animal animal);

		public IQueryable<Animal> Animals
		{ get { return db.Animals; } }

		public Animal Save(Animal animal)
		{
			db.Animals.Add(animal);
			db.SaveChanges();
			return animal;
		}

		public Animal Edit(Animal animal)
		{
			db.Entry(animal).State = EntityState.Modified;
			db.SaveChanges();
			return animal;
		}

		public void Remove(Animal animal)
		{
			db.Animals.Remove(animal);
			db.SaveChanges();
		}
    }
}
