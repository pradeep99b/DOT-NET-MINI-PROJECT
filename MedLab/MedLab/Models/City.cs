using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "State is required")]
        [ForeignKey("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
    }
}
