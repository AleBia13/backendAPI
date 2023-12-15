using DataAccessLayer.Models;

namespace BussinessLogicLayer.IServices
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationModel model, string role);
        //Task<(int, string)> Login(LoginModel model);
    }
}
