﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGO.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [StringLength(55, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [DisplayName("Neighborhood")]
        public int NeighborhoodId { get; set; }

        [Phone]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        public Neighborhood Neighborhood { get; set; }





        public List<Dog> Dogs { get; set; } = new List<Dog>();

    }
}
