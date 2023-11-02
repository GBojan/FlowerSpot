using FlowerSpot.Domain.Users;

namespace FlowerSpot.Service.Abstractions
{
    public interface IUserService
    {
        Task<LoginResponseModel> LoginAsync(LoginModel login);
        Task<RegisterResponseModel> RegisterAsync(RegisterModel model);
    }
}