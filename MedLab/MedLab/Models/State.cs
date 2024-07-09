using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "State name is required")]
        public string StateName { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
        public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    }
}
