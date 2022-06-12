namespace ContractManager.Business.Interfaces
{
    public interface IContractFileBusiness : IDomainBusiness<ContractFile, ContractFileDto>
    {
        public Task<ResponseBase<bool>> UploadAndCreate(UploadFileDto dto);
    }
}
