using DeepLome.Models.DatabaseModels;

namespace DeepLome.Services.Interfaces;

public interface IUserService
{
    public bool IsUserRegistered(User user);
    public List<string> RegisterUser(User user);
}