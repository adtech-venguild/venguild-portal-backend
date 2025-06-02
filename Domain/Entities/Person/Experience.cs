namespace VG.Domain.Entities.Person
{
    public class Experience
    {
        public int PersonId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
