using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Entity.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        [Required]
        public int GenderId { get; set; }
        public int? OccupationId { get; set; }
        public bool IsActive { get; set; }

        public Genders? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
