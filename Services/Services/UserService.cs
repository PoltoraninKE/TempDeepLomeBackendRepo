using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Repositories;


namespace DeepLome.Services.Services
{
    public class UserService
    {
        private UnitOfWork _unitOfWork;
        public UserService(UnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUserRegistered(User user) 
        {
            var users = _unitOfWork.Users().GetAll();
            if(users.Contains(user))
                return true;
            return false;
        }

        public List<string> RegisterUser(User user) 
        {
            var validateErrors = ValidateUserToRegister(user);
            return validateErrors;            
        }


        private List<string> ValidateUserToRegister(User user) 
        {
            List<string> validateErrors = new List<string>();
            if (IsUserRegistered(user))
                validateErrors.Add("User is already registered");
            return validateErrors;
        }

    }
}
