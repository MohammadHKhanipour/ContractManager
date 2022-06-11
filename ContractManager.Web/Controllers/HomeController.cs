using ContractManager.Business.Interfaces;
using ContractManager.Service.Interfaces;
using ContractManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContractManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContractBusiness _contractService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IContractBusiness contractService)
        {
            _logger = logger;
            _contractService = contractService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var result = await _contractService.GetAsync();
            return Ok(result);
        }
    }
}