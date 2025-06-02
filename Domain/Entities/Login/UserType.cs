namespace VG.Domain.Entities.Login
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; } = string.Empty;
    }
}
