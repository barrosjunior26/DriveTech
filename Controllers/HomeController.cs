using DriveTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DriveTech.Controllers
{
	public class HomeController : Controller
	{
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
	}
}
