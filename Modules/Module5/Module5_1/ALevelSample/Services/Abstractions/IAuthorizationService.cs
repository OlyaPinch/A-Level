using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelSample.Dtos.Responses;

namespace ALevelSample.Services.Abstractions
{
    public interface IAuthorizationService
    {
        Task<RegisterResponse> Registration(string email, string password = null);
        Task<LoginResponse> Login(string email, string password = null);
    }
}
