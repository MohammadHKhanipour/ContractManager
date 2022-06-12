namespace ContractManager.Business.Classes
{
    public class ContractFileBusiness : DomainBusiness<ContractFile, ContractFileDto>, IContractFileBusiness
    {
        private readonly IDomainService<ContractFile, ContractFileDto> _domainService;
        private readonly IUploadService _uploadService;

        public ContractFileBusiness(IDomainService<ContractFile, ContractFileDto> domainService, IUploadService uploadService) : base(domainService)
        {
            _domainService = domainService;
            _uploadService = uploadService;
        }

        public async Task<ResponseBase<bool>> UploadAndCreate(UploadFileDto dto)
        {
            var upload = await _uploadService.UploadFile(dto.File);
            if (upload.Status == ResponseStatus.Fail)
                return ResponseBase<bool>.Failure(ResponseStatus.Fail);

            var response = await _domainService.AddAsync(new ContractFileDto
            {
                ContractId = dto.ContractId,
                DateAdded = DateTime.Now,
                FileAddress = upload.Result,
                Name = dto.Name
            });

            if (response)
                return ResponseBase<bool>.Success(response);

            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }

    }
}
