using ContractManager.Business.Interfaces;
using ContractManager.Share.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadFileDto dto)
        {
            var result = await _contractFileBusiness.UploadAndCreate(dto);
            
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            return View();
        }

        public string FullPath(IHttpContextAccessor contextAccessor)
        {
            return string.Concat(contextAccessor.HttpContext.Request.Scheme
                , "://"
                , contextAccessor.HttpContext.Request.Host.ToUriComponent());

        }
    }
}