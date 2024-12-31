using Demo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class MenuController : Controller
	{


		public IActionResult Index()
		{
			return View();
		}
	}
}
