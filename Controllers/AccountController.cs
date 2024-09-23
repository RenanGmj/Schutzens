using Microsoft.AspNetCore.Mvc;
using ProjetoSZ.Models;
using ProjetoSZ.Services;
using System.Threading.Tasks;
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
                    // Logar o usuário manualmente, se necessário
                    // HttpContext.Session.SetString("UserEmail", user.Email); // Exemplo de como você pode salvar dados na sessão

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Este login não existe.");
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
                if (await _userService.UserExistsAsync(model.Email))
                {
                    ModelState.AddModelError(string.Empty, "Esse email ja esta sendo utilizado.");
                    return View(model);
                }

                var user = new Usuario
                {
                    Email = model.Email,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    DataDeNascimento = model.DataDeNascimento
                };

                var result = await _userService.CreateUserAsync(user, model.Senha);

                if (result != null)
                {
                    // Logar o usuário manualmente, se necessário
                    // HttpContext.Session.SetString("UserEmail", user.Email); // Exemplo de como você pode salvar dados na sessão

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Falha na criação do usuário.");
            }

            return View(model);
        }
    }
}
