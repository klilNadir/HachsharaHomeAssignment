namespace HachsharaHomeAssignment.Models
{
    public class InsurancePolicy
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public double InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsertId { get; set; }
        public User User { get; set; }
    }
}
