using HachsharaHomeAssignment.Services;
using HachsharaHomeAssignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HachsharaHomeAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UsersService usersService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, UsersService usersService)
        {
            _logger = logger;
            this.usersService = usersService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers(List<int> UserIds)
        {
            try
            {
                return Ok(usersService.GetUsers(UserIds));
            }
            catch (Exception ex)

            {
                _logger.LogError($"UserController GetUsers failed with ex {ex.Message} ");
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(UserViewModel user)
        {
            try
            {
                return Ok(usersService.CreateUser(user));
            }
            catch (Exception ex)

            {
                _logger.LogError($"UserController CreateUser  failed with ex {ex.Message} name {user.Name} ");
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(UserViewModel user)
        {
            try
            {
                return Ok(usersService.UpdateUser(user));
            }
            catch (Exception ex)

            {
                _logger.LogError($"UserController CreateUser  failed with ex {ex.Message} id {user.Id} ");
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                return Ok(usersService.DeleteUser(id));
            }
            catch (Exception ex)

            {
                _logger.LogError($"UserController CreateUser  failed with ex {ex.Message} id {id} ");
                return BadRequest(ex.Message);
            }
        }
    }
}
