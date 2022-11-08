using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAccountServices
    {
        Task SignUp(SignUpDTO signUp);

        Task SignIn(string email, string password);

        Task SignOut();
    }
}
