using DriveTech.Data;
using DriveTech.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult CadUsuario()
        {
            return View();
        }

		[HttpPost]
        public IActionResult CadUsuario(LoginModel novo)
        {
            if (ModelState.IsValid)
            {
                _banco.tb_login.Add(novo);
                _banco.SaveChanges();

                TempData["MensagemSucessoUser"] = "Cadastro de usuário realizado com sucesso.";
                
                return RedirectToAction("ListaUsuarios", "Login");
            }

            return View(novo);
        }

        [HttpGet]
        public IActionResult DetalhesUsuario(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LoginModel usuarios = _banco.tb_login.FirstOrDefault(u => u.Id == id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        [HttpPost]
        public IActionResult DetalhesUsuario(LoginModel atualizar)
        {
			if (ModelState.IsValid)
			{
				_banco.tb_login.Update(atualizar);
				_banco.SaveChanges();

				TempData["MensagemSucessoUpdate"] = "Cadastro de usuário atualizado com sucesso.";

				return RedirectToAction("ListaUsuarios", "Login");
			}

			return View(atualizar);
		}

        [HttpGet]
        public IActionResult ListaUsuarios()
        {
            var listaUsuarios = _banco.tb_login.ToList();
            return View(listaUsuarios);
        }

        public IActionResult Excluir(LoginModel excluir)
        {
            if(excluir == null)
            {
                return NotFound();
            }

            _banco.tb_login.Remove(excluir);
            _banco.SaveChanges();

            return Redirect("/Login/ListaUsuarios");
        }
	}
}
