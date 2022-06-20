﻿using System.Collections.Generic;

namespace DogGO.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NeighborhoodId { get; set; }
        public string Phone { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public List<Dog> Dogs { get; set; } = new List<Dog>();

    }
}
