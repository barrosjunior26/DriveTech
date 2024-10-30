using DriveTech.Data;
using DriveTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DriveTech.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _banco;
        public HomeController(ApplicationDbContext db)
        {
            _banco = db;
        }
        public IActionResult Index()
		{
			return View();
		}

		public IActionResult DriveTech()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult AcompanhamentoManutencao()
		{
			IEnumerable<ServicoModel> servicoModels = _banco.tb_servico;
			return View(servicoModels);
		}

		[HttpGet]
		public IActionResult Alerta(int? id)
		{
            if (id == null || id == 0)
            {
				return NotFound();
            }

			ServicoModel servicoModel = _banco.tb_servico.FirstOrDefault(x => x.Id == id);

			if (servicoModel == null)
			{
				return NotFound();
			}

			return View(servicoModel);
        }

	}
}
