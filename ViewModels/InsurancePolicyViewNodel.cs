namespace HachsharaHomeAssignment.ViewModels
{
    public class InsurancePolicyViewNodel
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public double InsuranceAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsertId { get; set; }
    }
}
