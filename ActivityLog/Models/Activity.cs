using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityLog.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required]
        public DateTime When { get; set; }
        [Required]
        public int NumberOfHours { get; set; }
        public int PersonId { get; set; }
        public virtual Person Who { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer AtCustomer { get; set; }

        [Required]
        public string Heading { get; set; }
        public string Description { get; set; }
        public bool On { get; set; }
    }
}