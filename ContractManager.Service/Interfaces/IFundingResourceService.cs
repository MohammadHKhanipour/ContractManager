namespace ContractManager.Service.Interfaces
{
    public interface IFundingResourceService : IDomainService<FundingResource, FundingResourceDto>
    {
        Task<int> GetCountById(int contractId);
    }
}
