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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IContractBusiness contractBusiness, IContractFileBusiness contractFileBusiness, IHttpContextAccessor httpContextAccessor)
        {
            _contractBusiness = contractBusiness;
            _contractFileBusiness = contractFileBusiness;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var result = FullPath(_httpContextAccessor);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadFileDto dto)
        {
            var result = await _contractFileBusiness.UploadAndCreate(dto, _httpContextAccessor);
            
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