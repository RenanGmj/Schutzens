using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoSZ.Models;

namespace Schutzens.Services
{
    public interface IUserService
    {
        Task<Usuario> CreateUserAsync(Usuario usuario, string senha);
        Task<Usuario> AuthenticateAsync(string email, string senha);
        Task<bool> UserExistsAsync(string email);
    }
}