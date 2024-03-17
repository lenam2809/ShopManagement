using Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public interface IAccount
    {
        Task<RegistrationResponse> RegisterAccountAsync(RegisterDTO register);
        Task<LoginResponse> LoginAccountAsync(LoginDTO login);
    }
}
