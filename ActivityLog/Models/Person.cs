using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActivityLog.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public int Age { get; set; }
        public virtual IEnumerable<Person> Manages { get; set; }

        public int? ManagerId { get; set; }
        public virtual Person Manager { get; set; }
    }

}