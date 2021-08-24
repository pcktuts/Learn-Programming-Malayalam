using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Programming_Malayalam.Areas.Admin.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Location { get; set; }

        [Display(Name = "Is Placed")] // this field is not used, remove it from DB
        public bool IsPlaced { get; set; }

        public string Company { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; }

        public Student()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
