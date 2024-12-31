using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
