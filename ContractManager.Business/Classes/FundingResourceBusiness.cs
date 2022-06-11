namespace ContractManager.Business.Classes
{
    public class FundingResourceBusiness : DomainBusiness<FundingResource, FundingResourceDto>, IFundingResourceBusiness
    {
        public FundingResourceBusiness(IDomainService<FundingResource, FundingResourceDto> domainService) : base(domainService)
        {
        }
    }
}
