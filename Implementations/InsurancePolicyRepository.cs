using HachsharaHomeAssignment.Interfaces;
using HachsharaHomeAssignment.Models;
using HachsharaHomeAssignment.Services;
using System;

namespace HachsharaHomeAssignment.Implementations
{
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private AppDbContext appDbContext;
        private readonly ILogger<InsurancePolicyRepository> _logger;

        public InsurancePolicyRepository(AppDbContext appDbContext, ILogger<InsurancePolicyRepository> logger)
        {
            this.appDbContext = appDbContext;
            _logger = logger;
        }

        public int CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            try
            {
                appDbContext.InsurancePolicies.Add(insurancePolicy);
                appDbContext.SaveChanges();
                return insurancePolicy.Id;

            }
            catch (Exception ex)
            {
                _logger.LogError($" InsurancePolicyRepository CreateInsurancePolicy failed with exception {ex}");
                throw new Exception($" InsurancePolicyRepository CreateInsurancePolicy failed with exception {ex}");
            }
        }

        public bool DeleteInsurancePolicy(int insurancePolicyId)
        {
            try
            {
                var insurancePolicy = appDbContext.InsurancePolicies.Where(i => i.Id == insurancePolicyId).FirstOrDefault();
                if (insurancePolicy != null)
                {
                    appDbContext.InsurancePolicies.Remove(insurancePolicy);
                    appDbContext.SaveChanges();
                    return true;
                }
                _logger.LogDebug($"InsurancePolicyRepository DeleteInsurancePolicy failed no insurance  policy found with Id {insurancePolicyId}");
                return false;


            }
            catch (Exception ex)
            {
                _logger.LogError($" InsurancePolicyRepository DeleteInsurancePolicy failed with exception {ex}");
                throw new Exception($" InsurancePolicyRepository DeleteInsurancePolicy failed with exception {ex}");
            }
        }

        public List<InsurancePolicy> GetInsurancePolicies(List<int> insurancePolicyIds)
        {
            List<InsurancePolicy> policies;
            if (insurancePolicyIds != null)
            {
                 policies = appDbContext.InsurancePolicies.Where(p => insurancePolicyIds.Contains(p.Id)).ToList();
            }
            else
            {
                policies= appDbContext.InsurancePolicies.ToList();
            }

            return policies;
        }

        public List<InsurancePolicy> GetInsurancePoliciesByUserIds(List<int> userIds)
        {
            List<InsurancePolicy> policies;
            if (userIds != null)
            {
                policies = appDbContext.InsurancePolicies.Where(p => userIds.Contains(p.UsertId)).ToList();
            }
            else
            {
                policies = appDbContext.InsurancePolicies.ToList();
            }

            return policies;
        }

        public bool UpdateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            try
            {
                var dbInsurancePolicy = appDbContext.InsurancePolicies.Where(i => i.Id == insurancePolicy.Id).FirstOrDefault();
                if (dbInsurancePolicy != null)
                {
                    dbInsurancePolicy.PolicyNumber = insurancePolicy.PolicyNumber;
                    dbInsurancePolicy.StartDate = insurancePolicy.StartDate;
                    dbInsurancePolicy.EndDate = insurancePolicy.EndDate;
                    dbInsurancePolicy.UsertId = insurancePolicy.UsertId;
                    dbInsurancePolicy.InsuranceAmount = insurancePolicy.InsuranceAmount;
                    appDbContext.SaveChanges();
                    return true;
                }
                _logger.LogDebug($"InsurancePolicyRepository UpdateInsurancePolicy failed no insurance  policy found with Id {insurancePolicy.Id}");
                return false;


            }
            catch (Exception ex)
            {
                _logger.LogError($" InsurancePolicyRepository UpdateInsurancePolicy failed with exception {ex}");
                throw new Exception($" InsurancePolicyRepository UpdateInsurancePolicy failed with exception {ex}");
            }
        }
    }
}
