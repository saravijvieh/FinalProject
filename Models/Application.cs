using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Application
    {
        // Primary Key for Application entity class
        public int ApplicationID {get; set;}

        [StringLength(30)]
        [Required]
        public string FirstName {get; set;}


        [StringLength(30)]
        [Required]
        public string LastName {get; set;}

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email {get;set;}

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber {get;set;}

        [Display(Name = "Cat")]
        [Required]
        public int CatId {get; set;} // Foreign Key linking Review to Movie
        public Cat Cat{get; set;} // Navigation Property
    }
}