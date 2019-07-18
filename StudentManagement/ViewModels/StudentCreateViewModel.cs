using Microsoft.AspNetCore.Http;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cant exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid Email")]
        [Display(Name = "Student Email")]
        public string Email { get; set; }
        [Required]
        public dept? Department { get; set; }
        public IFormFile photo { get; set; }
    }
}
