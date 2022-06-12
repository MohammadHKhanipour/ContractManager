using ContractManager.Business.Interfaces;
using ContractManager.Framework.Enums;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class FundingResourceController : Controller
    {
        private readonly IFundingResourceBusiness _fundingResourceBusiness;

        public FundingResourceController(IFundingResourceBusiness fundingResourceBusiness)
        {
            _fundingResourceBusiness = fundingResourceBusiness;
        }

        public async Task<IActionResult> ShowFundingResources(int contractId, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Error = message;
            ViewBag.ContractId = contractId;
            return View(await _fundingResourceBusiness.GetAllByContractId(contractId));
        }

        [HttpGet]
        public IActionResult AddFundingResource(int contractId)
        {
            ViewBag.ContractId = contractId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFundingResource(FundingResourceDto dto)
        {
            var result = await _fundingResourceBusiness.AddAsync(dto);
            return RedirectToAction("ShowFundingResources", "FundingResource", new { dto.ContractId });
        }

        [HttpGet]
        public async Task<IActionResult> EditFundingResource(int id, int contractId)
        {
            var response = await _fundingResourceBusiness.GetAsync(id);
            ViewBag.ContractId = contractId;
            if (response.Status == ResponseStatus.Fail)
                return RedirectToAction("ShowFundingResources", "FundingResource", new { contractId, message = "Add/Edit Failed" });

            return View(response.Result);
        }

        [HttpPost]
        public async Task<IActionResult> EditFundingResource(FundingResourceDto dto, int contractId)
        {
            var result = await _fundingResourceBusiness.UpdateAsync(dto);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("ShowFundingResources", "FundingResource", new { contractId });

            return RedirectToAction("ShowFundingResources", "FundingResource", new { contractId, message = "Add/Edit Failed" });
        }

        public async Task<IActionResult> DeleteFundingResource(int id, int contractId)
        {
            var result = await _fundingResourceBusiness.DeleteAsync(id);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("ShowFundingResources", "FundingResource", new { contractId });

            return RedirectToAction("ShowFundingResources", "FundingResource", new { contractId, message = "Delete Failed" });
        }
    }
}
