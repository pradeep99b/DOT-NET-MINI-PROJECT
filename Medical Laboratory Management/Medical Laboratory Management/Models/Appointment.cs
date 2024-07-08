using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_Laboratory_Management.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public string UserId { get; set; } // Foreign key for User

        [Required]
        [ForeignKey("Department")]
        [Display(Name = "Test Type")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        public TimeSpan AppointmentTime { get; set; } // Changed to TimeSpan

        [Display(Name = "Symptoms")]
        public string Symptoms { get; set; }

        public User User { get; set; } // Navigation property

        [Required]
        [ForeignKey("LabAssistant")]
        public int LabAssistantId { get; set; } // Foreign key for LabAssistant

        public LabAssistant LabAssistant { get; set; } // Navigation property
    }
}
