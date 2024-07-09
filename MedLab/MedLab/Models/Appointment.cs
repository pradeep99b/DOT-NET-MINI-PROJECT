using MedLab.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    [Required]
    public DateTime AppointmentDate { get; set; }

    [Required]
    [ForeignKey("Patient")]
    public int PatientId { get; set; }

    [Required]
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    [ForeignKey("LabAssistant")]
    public int? LabAssistantId { get; set; }  // Nullable to allow for appointments that might not have an assistant assigned yet

    public virtual Patient Patient { get; set; }
    public virtual Department Department { get; set; }
    public virtual LabAssistant LabAssistant { get; set; }
}