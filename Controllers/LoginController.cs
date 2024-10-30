using DriveTech.Data;
using DriveTech.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DriveTech.Controllers
{
	public class LoginController : Controller
	{
		private readonly ApplicationDbContext _banco;
        public LoginController(ApplicationDbContext db)
        {
            _banco = db;
        }

        [HttpGet]
		public IActionResult Entrar()
		{
			ClaimsPrincipal usuario = HttpContext.User;

            if (usuario.Identity.IsAuthenticated)
            {
                return Redirect("/Portal/Status");
            }

            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Entrar(string email, string senha)
        {
            LoginModel loginModel = _banco.tb_login.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            if (loginModel == null)
            {
                TempData["ErroLogin"] = "Login ou senha está incorreto. Por favor, tente novamente. Caso o problemas persistir, entre em contato com time de suporte.";
                return View();
            }

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, loginModel.Email));
            claims.Add(new Claim(ClaimTypes.Sid, loginModel.Id.ToString()));

            var identidadeUsuario = new ClaimsIdentity(claims, "Acesso");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identidadeUsuario);
            await HttpContext.SignInAsync("CookieAuthentication", claimsPrincipal, new AuthenticationProperties());

            return Redirect("/Portal/Status");
        }

        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login/Entrar");
        }
	}
}
