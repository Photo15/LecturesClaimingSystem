using System.ComponentModel.DataAnnotations.Schema;

namespace LecturesClaimingSystem.Models
{
    public class Claim
    {
        public int ID { get; set; } // Change 'object' to 'int'
        public string LecturerId { get; set; } // Example of another property
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public string AdditionalNotes { get; set; }
        public int ClaimId { get; set; }
        public string? LecturerName { get; set; }
        
       
        public string? Notes { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public string?SupportingDocument { get; set; } // Path to the uploaded file
        public object? Id { get; internal set; }
       
        public string? Email { get; set; }
        
        public decimal Amount { get; set; } // Example of another property, adjust as needed
        
       
        [NotMapped]
        public string? TemporaryData { get; set; }
       
       
        public DateTime CreatedAt { get; set; }

        public string? Description { get; set; }
            
            public string?FileName { get; set; }
 
          
    }


}

    

