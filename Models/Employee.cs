using System.ComponentModel.DataAnnotations;

namespace LecturesClaimingSystem.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Department { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}