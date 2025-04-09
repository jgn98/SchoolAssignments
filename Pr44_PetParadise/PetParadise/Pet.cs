﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public string Breed { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public double Weight { get; set; }

        public Pet()
        {

        }
        public Pet(int petId)
        {
            PetId = petId;
        }

        public override string ToString()
        {
            return $"{PetId}: {Name}, {PetType}, {Breed}, {DateOfBirth} 00:00:00, {Weight}";
        }
    }
}
