using DeepLome.WebApi.Models;

namespace DeepLome.Models.Interfaces;

public interface IUserService
{
    public bool IsUserRegistered(User user);
    public List<string> RegisterUser(User user);
}