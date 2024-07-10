using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedLab.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }

        [Required(ErrorMessage = "Appointment Id is required")]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }

        public  Appointment Appointment { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
