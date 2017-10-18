using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSanctuary.Models
{
    public class IVeterinarianRepository
    {
        IQueryable<Veterinarian> Veterinarians { get; }
        Veterinarian Save(Veterinarian veterinarian);
        Veterinarian Edit(Veterinarian veterinarian);
        void Remove(Veterinarian veterinarian);

		public IQueryable<Veterinarian> Veterinarians
		{ get { return db.Veterinarians; } }

		public Veterinarian Save(Veterinarian veterinarian)
		{
			db.Veterinarians.Add(veterinarian);
			db.SaveChanges();
			return veterinarian;
		}

		public Veterinarian Edit(Veterinarian veterinarian)
		{
			db.Entry(veterinarian).State = EntityState.Modified;
			db.SaveChanges();
			return veterinarian;
		}

		public void Remove(Veterinarian veterinarian)
		{
			db.veterinarians.Remove(veterinarian);
			db.SaveChanges();
		}
    }
}
