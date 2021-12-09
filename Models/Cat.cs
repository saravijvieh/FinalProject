using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Cat
    {
        public int CatID {get; set;}

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name {get; set;}

        public string Age {get; set;}

        [StringLength(30)]
        [Required]
        public string Breed {get; set;}

        public string Color {get; set;}

        [StringLength(5)]
        [Required]
        public string Gender {get; set;}

        public List<Application> Application {get; set;} // Navigation Property. One cat can have many applications        
    }
}