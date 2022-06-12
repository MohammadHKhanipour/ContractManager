using ContractManager.Business.Interfaces;
using ContractManager.Framework.Enums;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractBusiness _contractBusiness;

        public ContractController(IContractBusiness contractBusiness)
        {
            _contractBusiness = contractBusiness;
        }

        [HttpGet]
        public IActionResult AddContract()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContract(ContractDto dto)
        {
            var result = await _contractBusiness.AddAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditContract(int id)
        {
            var response = await _contractBusiness.GetAsync(id);

            if (response.Status == ResponseStatus.Fail)
                return RedirectToAction("Index", "Home", new { message = "Add/Edit Failed" });

            return View(response.Result);
        }

        [HttpPost]
        public async Task<IActionResult> EditContract(ContractDto dto)
        {
            var result = await _contractBusiness.UpdateAsync(dto);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home", new { message = "Add/Edit Failed" });
        }

        public async Task<IActionResult> DeleteContract(int id)
        {
            var result = await _contractBusiness.DeleteAsync(id);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home", new { message = "Delete Failed" });
        }
    }
}
