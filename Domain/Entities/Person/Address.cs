namespace VG.Domain.Entities.Person
{
    public class Address
    {
        public int PersonId { get; set; }
        public string AddressType { get; set; } // present, permanent
        public string BlkLotNumber { get; set; }
        public string StreetName { get; set; }
        public int City { get; set; }
        public int BarangayId { get; set; }
        public string ZipCode { get; set; }
        public string DisplayAddress { get; set; }

    }
}
