using DriveTech.Data;
using DriveTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveTech.Controllers
{
	public class PortalController : Controller
	{
		private readonly ApplicationDbContext _banco;
        public PortalController(ApplicationDbContext db)
        {
            _banco = db;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            var cadastro = new ServicoModel(); // Cria uma nova instância do modelo
			return View(cadastro);
        }

		[HttpPost]
        public async Task<IActionResult> Cadastro(ServicoModel novo, IFormFile Imagem)
		{
            if (ModelState.IsValid)
            {
                if (Imagem != null && Imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await Imagem.CopyToAsync(ms);
                        novo.Imagem = ms.ToArray();
                        novo.TipoImagem = Imagem.ContentType;
                    }
                }

                _banco.tb_servico.Add(novo);
                await _banco.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Dados gravados com sucesso!";

                return Redirect("/Portal/Status");
            }

            return View(novo);
        }

        [HttpGet]
        public async Task<IActionResult> Status()
        {
            var listaDeVeiculos = await _banco.tb_servico.ToListAsync();
            return View(listaDeVeiculos);
        }
	}
}
