using Microsoft.AspNetCore.Mvc;

namespace Proman.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public PartialViewResult _HeaderPartial()
		{
			return PartialView();
		}

		public PartialViewResult _SidebarPartial()
		{
			return PartialView();
		}

		public PartialViewResult _ScriptPartial()
		{
			return PartialView();
		}
	}
}
