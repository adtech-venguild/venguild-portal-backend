using VG.Domain.Entities.Enum;

namespace VG.Domain.Entities.Person
{
    public class Education
    {
        public int PersonId { get; set; }
        public EducationalAttainmentLevel Level { get; set; }
        public string SchooName { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
    }
}
