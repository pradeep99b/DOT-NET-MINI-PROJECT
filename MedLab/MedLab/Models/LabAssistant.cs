using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class LabAssistant
    {
        [Key]
        public int LabAssistantId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string LabAssistantName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
    }
}
