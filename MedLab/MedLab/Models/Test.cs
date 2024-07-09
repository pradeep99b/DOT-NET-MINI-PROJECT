using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{

    public class Test
    {
        [Key]
        public int TestId { get; set; }

        [Required(ErrorMessage = "Test name is required")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
