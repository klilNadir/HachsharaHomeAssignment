using HachsharaHomeAssignment.Services;
using HachsharaHomeAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HachsharaHomeAssignment.Controllers
{
    public class InsurancePolicyController : ControllerBase
    {
        private InsurancePolicyService insurancePolicyService;
        private readonly ILogger<UsersController> _logger;

        public InsurancePolicyController(InsurancePolicyService insurancePolicyService, ILogger<UsersController> logger)
        {
            this.insurancePolicyService = insurancePolicyService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetInsurancePoliciesByUserIds")]
        public IActionResult GetInsurancePoliciesByUserIds(List<int> UserIds)
        {
            try
            {
                return Ok(insurancePolicyService.GetInsurancePoliciesByUserIds(UserIds));
            }
            catch (Exception ex)

            {
                _logger.LogError($"InsurancePolicyController GetInsurancePoliciesByUserIds failed with ex {ex.Message} ");
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateInsurancePolicy")]
        public IActionResult CreateInsurancePolicy(InsurancePolicyViewNodel insurancePolicyViewNodel)
        {
            try
            {
                return Ok(insurancePolicyService.CreateInsurancePolicy(insurancePolicyViewNodel));
            }
            catch (Exception ex)

            {
                _logger.LogError($"InsurancePolicyController CreateInsurancePolicy  failed with ex {ex.Message} name {insurancePolicyViewNodel} ");
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateInsurancePolicy")]
        public IActionResult UpdateInsurancePolicy(InsurancePolicyViewNodel insurancePolicyViewNodel)
        {
            try
            {
                return Ok(insurancePolicyService.UpdateInsurancePolicy(insurancePolicyViewNodel));
            }
            catch (Exception ex)

            {
                _logger.LogError($"InsurancePolicyController UpdateInsurancePolicy  failed with ex {ex.Message} id {insurancePolicyViewNodel.Id} ");
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteInsurancePolicy")]
        public IActionResult DeleteInsurancePolicy(int id)
        {
            try
            {
                return Ok(insurancePolicyService.DeleteInsurancePolicy(id));
            }
            catch (Exception ex)

            {
                _logger.LogError($"InsurancePolicyController DeleteInsurancePolicy  failed with ex {ex.Message} id {id} ");
                return BadRequest(ex.Message);
            }
        }
    }
}
