using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Context;
using ProjetoSZ.Models;

namespace Schutzens.Services
{
    public class UserService: IUserService 
    {
        private readonly SchutzenDbContext _context;

        public UserService(SchutzenDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateUserAsync(Usuario usuario, string senha)
        {
            // Lógica para criar usuário (e.g., hash da senha)
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AuthenticateAsync(string email, string senha)
        {
            // Lógica para autenticar usuário
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }
    }
}