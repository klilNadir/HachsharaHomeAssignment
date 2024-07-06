using HachsharaHomeAssignment.Interfaces;
using HachsharaHomeAssignment.Models;
using HachsharaHomeAssignment.ViewModels;

namespace HachsharaHomeAssignment.Services
{
    public class InsurancePolicyService
    {
        private IInsurancePolicyRepository insurancePolicyRepository;
        private readonly ILogger<InsurancePolicyService> _logger;

        public InsurancePolicyService(IInsurancePolicyRepository insurancePolicyRepository, ILogger<InsurancePolicyService> logger)
        {
            this.insurancePolicyRepository = insurancePolicyRepository;
            _logger = logger;
        }

        public List<InsurancePolicyViewNodel> GetInsurancePoliciesByUserIds(List<int> userIds) 
        {
            var insurancePolicies = insurancePolicyRepository.GetInsurancePoliciesByUserIds(userIds);
            if (insurancePolicies == null)
            {
                if (userIds.Count > 0)
                {
                    throw new Exception($" no  policies  found  for users with ids {userIds} ");

                }
                else throw new Exception(" no policies found");
            }
            List<InsurancePolicyViewNodel> insurancePolicyViewNodels = new List<InsurancePolicyViewNodel>();
            foreach (var insurancePolicy in insurancePolicies)
            {
                insurancePolicyViewNodels.Add(ToViewModel(insurancePolicy));
            }
            return insurancePolicyViewNodels;
        }
        public List<InsurancePolicyViewNodel> GetInsurancePoliciesByIds(List<int> insurancePoliciesIds)
        {
            var insurancePolicies = insurancePolicyRepository.GetInsurancePolicies(insurancePoliciesIds);
            if (insurancePolicies == null)
            {
                if (insurancePoliciesIds.Count > 0)
                {
                    throw new Exception($" no   policies  found  with ids {insurancePoliciesIds} ");

                }
                else throw new Exception(" no policies found");
            }
            List<InsurancePolicyViewNodel> insurancePolicyViewNodels = new List<InsurancePolicyViewNodel>();
            foreach (var insurancePolicy in insurancePolicies)
            {
                insurancePolicyViewNodels.Add(ToViewModel(insurancePolicy));
            }
            return insurancePolicyViewNodels;
        }

        public int CreateInsurancePolicy(InsurancePolicyViewNodel viewModel)
        {
          return   insurancePolicyRepository.CreateInsurancePolicy(FromViewModel(viewModel));
        }
        public bool DeleteInsurancePolicy(int id)
        {
            return insurancePolicyRepository.DeleteInsurancePolicy( id);
        }
        public bool UpdateInsurancePolicy(InsurancePolicyViewNodel viewNodel)
        {
            return insurancePolicyRepository.UpdateInsurancePolicy(FromViewModel(viewNodel));
        }

        //in a bigger project user automapper or mapper class
        public InsurancePolicy FromViewModel(InsurancePolicyViewNodel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            return new InsurancePolicy { Id =viewModel.Id,PolicyNumber =viewModel.PolicyNumber,InsuranceAmount =viewModel.InsuranceAmount,StartDate =viewModel.StartDate ,EndDate =viewModel.EndDate ,UsertId =viewModel.UsertId};
        }
        public InsurancePolicyViewNodel ToViewModel(InsurancePolicy model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return new InsurancePolicyViewNodel {  Id = model.Id,PolicyNumber = model.PolicyNumber,InsuranceAmount=model.InsuranceAmount,StartDate = model.StartDate,EndDate =model.EndDate ,UsertId =model.UsertId};

        }
    }
}
