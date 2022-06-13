using DeepLome.Models.DatabaseModles;
using DeepLome.Models.Interfaces;
using DeepLome.Services.Interfaces;

namespace DeepLome.Services.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUserRegistered(User user) 
        {
            var users = _unitOfWork.Users.GetAll();
            if(users.Contains(user))
                return true;
            return false;
        }

        public List<string> RegisterUser(User user) 
        {
            var validateErrors = ValidateUserToRegister(user);
            return validateErrors;            
        }

        protected List<string> ValidateUserToRegister(User user) 
        {
            List<string> validateErrors = new List<string>();
            if (IsUserRegistered(user))
                validateErrors.Add("User is already registered");
            return validateErrors;
        }
    }
}
