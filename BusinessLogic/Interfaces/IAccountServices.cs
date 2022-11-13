using Core.DTOs;

namespace Core.Interfaces
{
    public interface IAccountServices
    {
        Task SignUp(SignUpDTO signUp);

        Task SignIn(string email, string password);

        Task SignOut();
    }
}
