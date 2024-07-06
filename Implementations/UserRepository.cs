using HachsharaHomeAssignment.Interfaces;
using HachsharaHomeAssignment.Models;
using HachsharaHomeAssignment.Services;

namespace HachsharaHomeAssignment.Implementations
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext appDbContext;
        private readonly ILogger<UsersService> _logger;

        public int CreateUser(User user)
        {
            try
            {
                appDbContext.Users.Add(user);
                appDbContext.SaveChanges();
                return user.Id;


            }
            catch (Exception ex)
            {
                _logger.LogError($" UserRepository createUser failed with exception {ex}");
                throw new Exception($" UserRepository createUser failed with exception {ex}");
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = appDbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
                if (user != null)
                {
                    appDbContext.Users.Remove(user);
                    appDbContext.SaveChanges();
                    return true;
                }
                _logger.LogDebug($"UserRepository DeleteUser failed no user found with Id {userId}");
                return false;


            }
            catch (Exception ex)
            {
                _logger.LogError($" UserRepository DeleteUser failed with exception {ex}");
                throw new Exception($" UserRepository DeleteUser failed with exception {ex}");
            }
        }

        public List<User> GetUsers(List<int> userIds)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var dbUser = appDbContext.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                if (dbUser != null)
                {
                    dbUser.Email = user.Email;
                    dbUser.Name = user.Name;

                    appDbContext.SaveChanges();
                    return true;
                }
                _logger.LogDebug($"UserRepository UpdateUser failed no user found with Id {user.Id}");
                return false;


            }
            catch (Exception ex)
            {
                _logger.LogError($" UserRepository createUser failed with exception {ex}");
                throw new Exception($" UserRepository createUser failed with exception {ex}");
            }
        }
    }
}
