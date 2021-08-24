using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Programming_Malayalam.Areas.Admin.Models
{
    public class Certificate
    {
        public enum EnumStatus
        {
            [Display(Name = "In Progress")]
            InProgress,
            [Display(Name = "Completed")]
            Completed,
            [Display(Name = "Discontinued")]
            Discontinued            
        }

        public int Id { get; set; }

        [Required]
        public EnumStatus Status { get; set; }

        public string ProjectUrl { get; set; }
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime CompletedAt { get; set; }


        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Certificate()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
