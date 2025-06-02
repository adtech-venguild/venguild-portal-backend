namespace VG.Domain.Entities.Person
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string MobileNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string TaxNumber { get; set; }
        public string PhilHealthNumber { get; set; }
        public string PagIbigNumber { get; set; }
        public string SSSNumber { get; set; }
        public string Status { get; set; }
    }
}
