using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class CorrespondenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
