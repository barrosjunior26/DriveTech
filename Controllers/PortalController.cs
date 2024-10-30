using DriveTech.Data;
using DriveTech.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DriveTech.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
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
            var cadastro = new ServicoModel(); //Cria uma nova instância do modelo
			return View(cadastro);
        }

		[HttpPost]
        public async Task<IActionResult> Cadastro(ServicoModel novo)
		{
            if (ModelState.IsValid)
            {
                _banco.tb_servico.Add(novo);
                await _banco.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Dados gravados com sucesso!";

                return Redirect("/Portal/Status");
            }

            return View(novo);
        }

        [HttpGet]
        public IActionResult Status()
        {
            var listaDeVeiculos = _banco.tb_servico.ToList();
            return View(listaDeVeiculos);
        }

        [HttpGet]
        public IActionResult Atualizar(int? id)
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

		[HttpPost]
		public async Task<IActionResult> Atualizar(ServicoModel atualizar)
		{
            if (atualizar == null)
            {
                return BadRequest("Modelo não pode ser nulo.");
            }


            if (!ModelState.IsValid)
            {
                return View(atualizar);
            }

            var servicoExistente = await _banco.tb_servico.FindAsync(atualizar.Id);

            if (servicoExistente == null)
            {
                return NotFound();
            }

            servicoExistente.Proprietario = atualizar.Proprietario;
            servicoExistente.Placa = atualizar.Placa;
            servicoExistente.Marca = atualizar.Marca;
            servicoExistente.Modelo = atualizar.Modelo;
            servicoExistente.Cor = atualizar.Cor;
            servicoExistente.Status = atualizar.Status;
            servicoExistente.Valor = atualizar.Valor;
            servicoExistente.Observacoes = atualizar.Observacoes;
            servicoExistente.Alerta = atualizar.Alerta;
            servicoExistente.MensagemAlerta = atualizar.MensagemAlerta;

            await _banco.SaveChangesAsync();

			TempData["MensagemSucessoUpdate"] = "Dados atualizados com sucesso!";

            return RedirectToAction("Status");
		}

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServicoModel excluir = _banco.tb_servico.FirstOrDefault(x => x.Id == id);

            if (excluir == null)
            {
                return NotFound();
            }

            return View(excluir);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(ServicoModel excluir)
        {
            if (excluir == null)
            {
                return NotFound();
            }

            _banco.tb_servico.Remove(excluir);
            await _banco.SaveChangesAsync();

            return RedirectToAction("Status");
        }
	}
}
