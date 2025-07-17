using VG.Domain.Entities;
using VG.Domain.Entities.Common;
using VG.Domain.Entities.Enum;

namespace VG.Domain.Entities.Login
{
    public class User : BaseEntity
    {
        public Guid Id { get; set; }                  // Unique identifier
        public string Email { get; set; }             // User's email
        public string Password { get; set; }          // Hashed password
        public bool Deleted { get; set; }             // Soft delete flag
        public RecordStatus Status { get; set; }      // Custom status (e.g., Active, Inactive)
        public string Contact { get; set; }           // Contact number or info
        public bool Verified { get; set; }            // Email or account verification status
        public string VerificationTerms { get; set; } // Terms related to verification email/mobile
        public int UserTypeId { get; set; }           // Identifier for the user's role or type
    }
}
