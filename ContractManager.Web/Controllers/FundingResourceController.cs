using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class FundingResourceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
