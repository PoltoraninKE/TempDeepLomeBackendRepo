using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Repositories;


namespace DeepLome.Services.Services
{
    public class UserService
    {
        UsersRepository _userRepository;
        public UserService(UsersRepository usersRepository) 
        {
            _userRepository = usersRepository;
        }

        public bool IsUserAllowed(User user) 
        {
            if (_userRepository.GetById(user.Id) != null) 
                return true;
            return false;
        } 
    }
}
