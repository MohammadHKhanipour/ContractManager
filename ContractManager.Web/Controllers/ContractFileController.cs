using ContractManager.Business.Interfaces;
using ContractManager.Framework.Enums;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Text;

namespace ContractManager.Web.Controllers
{
    public class ContractFileController : Controller
    {
        private readonly IContractFileBusiness _contractFileBusiness;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContractFileController(IContractFileBusiness contractFileBusiness, IHttpContextAccessor contextAccessor)
        {
            _contractFileBusiness = contractFileBusiness;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> ShowContractFiles(int contractId, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.Error = message;
            ViewBag.ContractId = contractId;
            return View(await _contractFileBusiness.GetAllByContractId(contractId));
        }

        [HttpGet]
        public IActionResult AddContractFile(int contractId)
        {
            ViewBag.ContractId = contractId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContractFile(UploadFileDto dto)
        {
            var result = await _contractFileBusiness.UploadAndCreate(dto);
            return RedirectToAction("ShowContractFiles", "ContractFile", new { dto.ContractId });
        }

        public async Task<IActionResult> DeleteContractFile(int id, int contractId)
        {
            var result = await _contractFileBusiness.DeleteAsync(id);

            if (result.Status == ResponseStatus.Success)
                return RedirectToAction("ShowContractFiles", "ContractFile", new { contractId });

            return RedirectToAction("ShowContractFiles", "ContractFile", new { contractId, message = "Delete Failed" });
        }

        public async Task<IActionResult> DownloadFile(int fileId)
        {
            var response = await _contractFileBusiness.GetAsync(fileId);
            if (response.Status == ResponseStatus.NotFound)
                return NotFound(ResponseStatus.NotFound);

            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files")).Root + $@"\{response.Result.FileAddress}";
            var bytes = System.IO.File.ReadAllBytes(filepath);
            return File(bytes, "application/octet-stream", response.Result.FileAddress);
        }
    }
}
