using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ContractManager.Share.DTOs
{
    public class UploadFileDto : BaseDto
    {
        public int ContractId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public IFormFile? File { get; set; }
    }
}
