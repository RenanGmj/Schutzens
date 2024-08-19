using Microsoft.AspNetCore.Mvc;
using ProjetoSZ.Models;
using System.Threading.Tasks;
using Schutzens.Services;
using ProjetoSZ.Models.UIModels;

namespace ProjetoSZ.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateAsync(model.Email, model.Password);
                if (user != null)
                {
                    // A autenticação foi bem-sucedida
                    // Adicione uma lógica para criar uma sessão ou um cookie se necessário
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userService.UserExistsAsync(model.Email);
                if (userExists)
                {
                    ModelState.AddModelError(string.Empty, "Email already exists.");
                    return View(model);
                }

                var user = new Usuario
                {
                    Email = model.Email,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    DataDeNascimento = model.DataDeNascimento,
                    Senha = model.Senha
                };

                var result = await _userService.CreateUserAsync(user, model.Senha);

                if (result != null)
                {
                    // A criação do usuário foi bem-sucedida
                    // Adicione uma lógica para criar uma sessão ou um cookie se necessário
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Failed to create user.");
            }

            return View(model);
        }
    }
}
