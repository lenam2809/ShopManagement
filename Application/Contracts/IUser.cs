using Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterAsync(RegisterDTO register);
        Task<LoginResponse> LoginAsync(LoginDTO login);
    }
}
