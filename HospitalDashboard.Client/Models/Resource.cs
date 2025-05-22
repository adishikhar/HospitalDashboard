namespace HospitalDashboard.Client.Models
{
    public class Resource
    {
        public string Id { get; set; }
        public string Type { get; set; } // Bed, Doctor, Equipment
        public string Name { get; set; }
        public string Status { get; set; } // Available, In Use, etc.
    }
}
