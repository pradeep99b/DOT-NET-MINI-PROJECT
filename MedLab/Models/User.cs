using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public  class User
    {   
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Age is required")]
            [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
            public int Age { get; set; }

            [Required(ErrorMessage = "Gender is required")]
            public Gender Gender { get; set; }

            [Required(ErrorMessage = "Phone number is required")]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
            public string? PhoneNumber { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Address is required")]
            public string? Address { get; set; }

            [Required(ErrorMessage = "State is required")]
            [System.ComponentModel.DataAnnotations.Schema.ForeignKey("State")]
            public int StateId { get; set; }

            [Required(ErrorMessage = "City is required")]
            [System.ComponentModel.DataAnnotations.Schema.ForeignKey("City")]
            public int CityId { get; set; }

            [Required(ErrorMessage = "Blood group is required")]
            public BloodGroup BloodGroup { get; set; }

            public  State? State { get; set; }

            public  City? City { get; set; }

            public  ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
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
