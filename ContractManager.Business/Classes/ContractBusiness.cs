using ContractManager.Service.Interfaces;

namespace ContractManager.Business.Classes
{
    public class ContractBusiness : DomainBusiness<Contract, ContractDto>, IContractBusiness
    {
        private readonly IContractFileService _contractFileService;
        private readonly ICorrespondenceService _correspondenceService;
        private readonly IFundingResourceService _fundingResourceService;
        private readonly IDomainService<Contract, ContractDto> _domainService;

        public ContractBusiness(IDomainService<Contract, ContractDto> domainService, IContractFileService contractFileService, ICorrespondenceService correspondenceService, IFundingResourceService fundingResourceService)
            : base(domainService)
        {
            _contractFileService = contractFileService;
            _correspondenceService = correspondenceService;
            _fundingResourceService = fundingResourceService;
            _domainService = domainService;
        }

        public async Task<ListResponseBase<ShowContractDto>> GetAllContracts()
        {
            var contracts = await _domainService.GetAsync();
            
            if (contracts == null || !contracts.Any())
                return ListResponseBase<ShowContractDto>.Failure(ResponseStatus.NotFound);

            var showContractDtos = new List<ShowContractDto>();

            foreach (var contract in contracts)
            {
                showContractDtos.Add(
                    new ShowContractDto
                    {
                        Id = contract.Id,
                        ContractSide = contract.ContractSide,
                        ContractStatus = contract.ContractStatus,
                        ContractType = contract.ContractType,
                        Cost = contract.Cost,
                        DueDate = contract.DueDate.ToShortDateString(),
                        StartDate = contract.StartDate.ToShortDateString(),
                        FinalCost = contract.FinalCost,
                        Number = contract.Number,
                        Subject = contract.Subject,
                        PaymentType = contract.PaymentType,
                        CorrespondencesCount = await _correspondenceService.GetCountById(contract.Id),
                        DocumentationsCount = await _contractFileService.GetCountById(contract.Id),
                        FundingResourcesCount = await _fundingResourceService.GetCountById(contract.Id),
                    }
                );
            }

            return ListResponseBase<ShowContractDto>.Success(showContractDtos);
        }
    }
}
