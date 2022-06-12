namespace ContractManager.Service.Interfaces
{
    public interface IContractFileService : IDomainService<ContractFile, ContractFileDto>
    {
        Task<int> GetCountById(int contractId);
    }
}
