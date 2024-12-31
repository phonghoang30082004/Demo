using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Edit_Profile()
		{
			return View();
		}
		public IActionResult Delete_Profile()
		{
			return View();
		}
		public IActionResult Order_User()
		{
			return View("Order_User");

		}

	}
}
