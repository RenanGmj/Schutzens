using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Context;
using ProjetoSZ.Models;
using System.Threading.Tasks;

namespace ProjetoSZ.Services
{
    public interface IUserService
    {
        Task<Usuario> CreateUserAsync(Usuario usuario, string senha);
        Task<Usuario> AuthenticateAsync(string email, string senha);
        Task<bool> UserExistsAsync(string email);
    }

    public class UserService : IUserService
    {
        private readonly SchutzenDbContext _context;

        public UserService(SchutzenDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CreateUserAsync(Usuario usuario, string senha)
        {
            // Criptografar a senha usando BCrypt
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(senha);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AuthenticateAsync(string email, string senha)
        {
            // Buscar o usuário
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user != null && BCrypt.Net.BCrypt.Verify(senha, user.Senha))
            {
                return user;
            }

            return null;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }
    }
}
