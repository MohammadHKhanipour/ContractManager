namespace ContractManager.Business.Interfaces
{
    public interface IFundingResourceBusiness : IDomainBusiness<FundingResource, FundingResourceDto>
    {
        Task<ListResponseBase<FundingResourceDto>> GetAllByContractId(int contractId);
    }
}
