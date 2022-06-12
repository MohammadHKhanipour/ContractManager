using ContractManager.Business.Interfaces;
using ContractManager.Framework.Enums;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class ContractFileController : Controller
    {
        private readonly IContractFileBusiness _contractFileBusiness;

        public ContractFileController(IContractFileBusiness contractFileBusiness)
        {
            _contractFileBusiness = contractFileBusiness;
        }

        public async Task<IActionResult> Index(string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Error = message;

            return View(await _contractFileBusiness.GetAsync());
        }

        [HttpGet]
        public IActionResult AddContractFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContractFile(ContractFileDto dto)
        {
            var result = await _contractFileBusiness.AddAsync(dto);
            return Ok(result);
        }

        public async Task<IActionResult> DeleteContractFile(int id)
        {
            var result = await _contractFileBusiness.DeleteAsync(id);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("Index", "ContractFile");

            return RedirectToAction("Index", "ContractFile", new { message = "Delete Failed" });
        }
    }
}
