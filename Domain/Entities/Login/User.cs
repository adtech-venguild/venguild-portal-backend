using VG.Domain.Entities;

namespace VG.domain.Entities.Login
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }                  // Unique identifier
        public string Email { get; set; }             // User's email
        public string Password { get; set; }          // Hashed password
        public bool Deleted { get; set; }             // Soft delete flag
        public string Status { get; set; }            // Custom status (e.g., Active, Inactive)
        public string Contact { get; set; }           // Contact number or info
        public bool Verified { get; set; }            // Email or account verification status
        public string VerificationTerms { get; set; } // Terms related to verification email/mobile
    }
}
