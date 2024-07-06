using HachsharaHomeAssignment.Models;

namespace HachsharaHomeAssignment.Interfaces
{
    public interface IInsurancePolicyRepository
    {
        public List<InsurancePolicy> GetInsurancePolicies(List<int> insurancePolicyIds);
        public List<InsurancePolicy> GetInsurancePoliciesByUserIds(List<int> userIds);
        public bool UpdateInsurancePolicy(InsurancePolicy insurancePolicy);
        public bool DeleteInsurancePolicy(int insurancePolicyId);
        public int CreateInsurancePolicy(InsurancePolicy insurancePolicy);
    }
}
