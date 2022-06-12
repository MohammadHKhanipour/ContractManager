using ContractManager.Service.Interfaces;

namespace ContractManager.Business.Classes
{
    public class FundingResourceBusiness : DomainBusiness<FundingResource, FundingResourceDto>, IFundingResourceBusiness
    {
        private readonly IFundingResourceService _fundingResourceService;

        public FundingResourceBusiness(IDomainService<FundingResource, FundingResourceDto> domainService,
            IFundingResourceService fundingResourceService)
            : base(domainService)
        {
            _fundingResourceService = fundingResourceService;
        }

        public async Task<ListResponseBase<FundingResourceDto>> GetAllByContractId(int contractId)
        {
            var fundingResources = await _fundingResourceService.GetAllByContractId(contractId);

            if (fundingResources == null || !fundingResources.Any())
                return ListResponseBase<FundingResourceDto>.Failure(ResponseStatus.NotFound);

            return ListResponseBase<FundingResourceDto>.Success(fundingResources);
        }
    }
}
