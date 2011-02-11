using System.ComponentModel.DataAnnotations;

namespace ActivityLog.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]public string Name { get; set; }
        public string Contact { get; set; }
        public string Extra { get; set; }
    }
}