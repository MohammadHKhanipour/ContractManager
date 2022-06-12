﻿using ContractManager.Business.Interfaces;
using ContractManager.Framework.Enums;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContractManager.Web.Controllers
{
    public class CorrespondenceController : Controller
    {
        private readonly ICorrespondenceBusiness _correspondenceBusiness;

        public CorrespondenceController(ICorrespondenceBusiness correspondenceBusiness)
        {
            _correspondenceBusiness = correspondenceBusiness;
        }

        public async Task<IActionResult> ShowCorrespondences(int contractId, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Error = message;

            return View(await _correspondenceBusiness.GetAllByContractId(contractId));
        }

        [HttpGet]
        public IActionResult AddCorrespondence()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCorrespondence(CorrespondenceDto dto)
        {
            var result = await _correspondenceBusiness.AddAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditCorrespondence(int id, int contractId)
        {
            var response = await _correspondenceBusiness.GetAsync(id);

            if (response.Status == ResponseStatus.Fail)
                return RedirectToAction("Index", "Correspondence", new { contractId, message = "Add/Edit Failed" });

            return View(response.Result);
        }

        [HttpPost]
        public async Task<IActionResult> EditCorrespondence(CorrespondenceDto dto, int contractId)
        {
            var result = await _correspondenceBusiness.UpdateAsync(dto);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("Index", "Correspondence", new { contractId });

            return RedirectToAction("Index", "Correspondence", new { contractId, message = "Add/Edit Failed" });
        }

        public async Task<IActionResult> DeleteCorrespondence(int id, int contractId)
        {
            var result = await _correspondenceBusiness.DeleteAsync(id);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("ShowCorrespondences", "Correspondence", new { contractId });

            return RedirectToAction("ShowCorrespondences", "Correspondence", new { contractId , message = "Delete Failed" });
        }
    }
}
