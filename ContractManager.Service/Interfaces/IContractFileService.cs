namespace ContractManager.Service.Interfaces
{
    public interface IContractFileService : IDomainService<ContractFile, ContractFileDto>
    {
        Task<List<ContractFileDto>> GetAllByContractId(int contractId);
        Task<int> GetCountById(int contractId);
    }
}
