using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }

        [Required(ErrorMessage = "Test Name is required")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Department Id is required")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }


        public Department? Department { get; set; }
    }
}
