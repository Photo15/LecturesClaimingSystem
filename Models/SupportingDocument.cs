namespace LecturesClaimingSystem.Models
{
    public class SupportingDocument
    {
        public string? LecturerName { get; set; } // Consider making this nullable
        public string? Notes { get; set; } // Consider making this nullable
        public int Id { get; set; }
        public string? DocumentPath { get; set; }
        public SupportingDocument()
        {
            // Initialize properties or consider making them nullable
        }
    }
}