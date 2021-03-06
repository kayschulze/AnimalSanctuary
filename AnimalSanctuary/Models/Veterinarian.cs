﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalSanctuary.Models
{
    [Table("Veterinarians")]
    public class Veterinarian
    {
        [Key]
        public int VeterinarianId;
        public string Name;
        public string Specialty;

		public override bool Equals(System.Object otherVeterinarian)
		{
            if (!(otherVeterinarian is Veterinarian))
			{
				return false;
			}
			else
			{
				Veterinarian newVeterinarian = (Veterinarian)otherVeterinarian;
				return this.VeterinarianId.Equals(newVeterinarian.VeterinarianId);
			}
		}

		public override int GetHashCode()
		{
            return this.VeterinarianId.GetHashCode();
		}
    }
}
