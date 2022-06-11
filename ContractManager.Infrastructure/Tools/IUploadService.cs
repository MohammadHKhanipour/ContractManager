using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Text;

namespace ContractManager.Infrastructure.Tools
{
    public interface IUploadService
    {
        Task<ResponseBase<string>> UploadFile(IFormFile file, IHttpContextAccessor httpContextAccessor);
    }

    public class UploadService : IUploadService
    {
        public async Task<ResponseBase<string>> UploadFile(IFormFile file, IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var fileExtension = Path.GetExtension(file.FileName);
                    var newFileName = string.Concat(myUniqueFileName, fileExtension);
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files")).Root + $@"\{newFileName}";

                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        await file.CopyToAsync(fs);
                        await fs.FlushAsync();
                    }

                    var outputPath = CreatePath(httpContextAccessor,"files",newFileName);
                    
                    return ResponseBase<string>.Success(outputPath);
                }
                return ResponseBase<string>.Failure(Framework.Enums.ResponseStatus.Fail);
            }
            catch (Exception ex)
            {
                return ResponseBase<string>.Failure(Framework.Enums.ResponseStatus.Fail);
            }
        }

        private string CreatePath(IHttpContextAccessor contextAccessor, string folderName, string fileName)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(contextAccessor.HttpContext.Request.Scheme);
            stringBuilder.Append("://");
            stringBuilder.Append(contextAccessor.HttpContext.Request.Host.ToUriComponent());
            stringBuilder.Append("/");
            stringBuilder.Append(folderName);
            stringBuilder.Append("/");
            stringBuilder.Append(fileName);
            return stringBuilder.ToString();
        }
    }
}
