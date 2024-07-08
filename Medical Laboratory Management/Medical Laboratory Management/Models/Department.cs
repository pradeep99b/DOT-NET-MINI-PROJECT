using System.Collections.Generic;

namespace Medical_Laboratory_Management.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<LabAssistant> LabAssistants { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
