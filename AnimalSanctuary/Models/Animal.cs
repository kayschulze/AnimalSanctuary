using System;

namespace AnimalSanctuary.Models
{
    public class Animal
    {
        public int AnimalId;
        public string Name;
        public string Species;
        public string Sex;
        public string HabitatType;
        public bool MedicalEmergency;
        public int VeterinarianId;
        public string Veterinarian;

		public override bool Equals(System.Object otherAnimal)
		{
			if (!(otherAnimal is Animal))
			{
				return false;
			}
			else
			{
				Animal newAnimal = (Animal)otherAnimal;
                return this.AnimalId.Equals(newAnimal.AnimalId);
			}
		}

		public override int GetHashCode()
		{
			return this.ItemId.GetHashCode();
		}
    }
}
