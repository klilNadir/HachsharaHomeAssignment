using HachsharaHomeAssignment.Interfaces;
using HachsharaHomeAssignment.Models;
using HachsharaHomeAssignment.ViewModels;

namespace HachsharaHomeAssignment.Services
{
    public class UsersService
    {
        private IUserRepository userRepository;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUserRepository userRepository, ILogger<UsersService> logger)
        {
            this.userRepository = userRepository;
            _logger = logger;
        }

        public List<UserViewModel> GetUsers(List<int> userIds)
        {
            var users = userRepository.GetUsers(userIds);
            if (users == null)
            {
                if (userIds.Count > 0)
                {
                    throw new Exception($" no  user found with ids {userIds} ");

                }
                else throw new Exception(" no user found");
            }
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModels.Add(ToViewModel(user));
            }
            return userViewModels;
        }




        public int CreateUser(UserViewModel user)
        {

            return userRepository.CreateUser(FromViewModel(user));
        }
        public bool UpdateUser(UserViewModel user)
        {
            return userRepository.UpdateUser(FromViewModel(user));
        }
        public bool DeleteUser(int id)
        {
            return userRepository.DeleteUser(id);
        }

        //in a bigger project user automapper or mapper class
        public User FromViewModel(UserViewModel viewModel)
        {
            return new User() { Id = viewModel.Id, Name = viewModel.Name, Email = viewModel.Email };
        }
        public UserViewModel ToViewModel(User user)
        {
            return new UserViewModel() { Id = user.Id, Name = user.Name, Email = user.Email };
        }



    }
}
