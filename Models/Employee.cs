using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int ClaimId { get; set; }
        public string? LecturerName { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public string? SupportingDocument { get; set; } // Path to the uploaded file
        public object? Id { get; internal set; }
       
        public string LecturerId { get; set; }
     
        [NotMapped]
        public string TemporaryData { get; set; }
        public string AdditionalNotes { get; set; }
        // Consider adding a Status property if needed
        public DateTime CreatedAt { get; set; }
    }
}