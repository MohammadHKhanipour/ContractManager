namespace ContractManager.Business.Interfaces
{
    public interface IContractFileBusiness : IDomainBusiness<ContractFile, ContractFileDto>
    {
        Task<ListResponseBase<ContractFileDto>> GetAllByContractId(int contractId);
        public Task<ResponseBase<bool>> UploadAndCreate(UploadFileDto dto);
    }
}
