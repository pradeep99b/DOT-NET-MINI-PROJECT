using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedLab.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }

        [Required(ErrorMessage = "Appointment Id is required")]
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
