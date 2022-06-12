using ContractManager.Business.Interfaces;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContractBusiness _contractBusiness;
        private readonly IContractFileBusiness _contractFileBusiness;

        public HomeController(IContractBusiness contractBusiness, IContractFileBusiness contractFileBusiness)
        {
            _contractBusiness = contractBusiness;
            _contractFileBusiness = contractFileBusiness;
        }

        public async Task<IActionResult> Index(string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Error = message;

            return View(await _contractBusiness.GetAllContracts());
        }

        //[HttpPost]
        //public async Task<IActionResult> Upload(UploadFileDto dto)
        //{
        //    var result = await _contractFileBusiness.UploadAndCreate(dto);

        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Upload()
        //{
        //    return View();
        //}
    }
}