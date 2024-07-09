using MedLab.Models;
using System.ComponentModel.DataAnnotations;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Department name is required")]
    public string DepartmentName { get; set; }

    public virtual ICollection<Test> Tests { get; set; } = new HashSet<Test>();
    public virtual ICollection<LabAssistant> LabAssistants { get; set; } = new HashSet<LabAssistant>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
}