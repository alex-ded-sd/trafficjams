namespace TrafficJams.WebClient.Controller
{
	using Microsoft.AspNetCore.Mvc;
	using Controller = Microsoft.AspNetCore.Mvc.Controller;

	public class HomeController : Controller
	{
		// GET
		public IActionResult Index()
		{
			return View();
		}
	}
}