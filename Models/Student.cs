using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaorPages.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please fill the first name")]
        [RegularExpression(@"[A-z]*", ErrorMessage = "Use only alphabets.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please fill the last name")]
        [RegularExpression(@"[A-z]*", ErrorMessage = "Use only alphabets.")]
        [StringLength(50,ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please fill the phone number")]
        [RegularExpression(@"[+][0-9]*$", ErrorMessage = "Please start with country code ")] //PhoneNumber has start with +
        public string PhoneNumber { get; set; }
        
        public string ImageName { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
