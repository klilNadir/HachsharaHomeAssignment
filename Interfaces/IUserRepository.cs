using HachsharaHomeAssignment.Models;

namespace HachsharaHomeAssignment.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsers(List<int> userIds);
        public bool UpdateUser(User user);
        public bool DeleteUser(int userId);
        public int CreateUser(User user);
    }
}
