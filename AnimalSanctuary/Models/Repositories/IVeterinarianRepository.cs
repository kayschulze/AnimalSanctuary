using System.Linq;

namespace AnimalSanctuary.Models
{
    public interface IVeterinarianRepository
    {
        IQueryable<Veterinarian> Veterinarians { get; }
        Veterinarian Save(Veterinarian veterinarian);
        Veterinarian Edit(Veterinarian veterinarian);
        void Remove(Veterinarian veterinarian);
    }
}
