using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int PatientAge { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "State is required")]
          [ForeignKey("State")]
          public int StateId { get; set; }

        [Required(ErrorMessage = "City is required")]
        [ForeignKey("City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Blood group is required")]
        public BloodGroup BloodGroup { get; set; }

        public virtual State State { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }

    public enum Gender
    {
        MALE,
        FEMALE
    }

    public enum BloodGroup
    {
        O_Positive,
        O_Negative,
        A_Positive,
        A_Negative,
        B_Positive,
        B_Negative,
        AB_Positive,
        AB_Negative
    }
}
