namespace ContractManager.Infrastructure.Tools
{
    public interface IUploadService
    {
        Task<ResponseBase<string>> UploadFile(IFormFile file);
    }

    public class UploadService : IUploadService
    {
        public async Task<ResponseBase<string>> UploadFile(IFormFile file)
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
                    return ResponseBase<string>.Success(newFileName);
                }
                return ResponseBase<string>.Failure(Framework.Enums.ResponseStatus.Fail);
            }
            catch (Exception ex)
            {
                return ResponseBase<string>.Failure(Framework.Enums.ResponseStatus.Fail);
            }
        }
    }
}
