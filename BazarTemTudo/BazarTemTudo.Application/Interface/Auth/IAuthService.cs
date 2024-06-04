using BazarTemTudo.Application.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.Interface.Auth
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginViewModel loginDto);
        Task LogoutAsync();
    }
}
