namespace ContractManager.Service.Interfaces
{
    public interface IFundingResourceService : IDomainService<FundingResource, FundingResourceDto>
    {
        Task<List<FundingResourceDto>> GetAllByContractId(int contractId);
        Task<int> GetCountById(int contractId);
    }
}
