using ContractManager.Service.Interfaces;

namespace ContractManager.Business.Classes
{
    public class CorrespondenceBusiness : DomainBusiness<Correspondence, CorrespondenceDto>, ICorrespondenceBusiness
    {
        private readonly ICorrespondenceService _correspondenceService;

        public CorrespondenceBusiness(IDomainService<Correspondence, CorrespondenceDto> domainService,
            ICorrespondenceService correspondenceService)
            : base(domainService)
        {
            _correspondenceService = correspondenceService;
        }

        public async Task<ListResponseBase<CorrespondenceDto>> GetAllByContractId(int contractId)
        {
            var correspondences = await _correspondenceService.GetAllByContractId(contractId);

            if (correspondences == null || !correspondences.Any())
                return ListResponseBase<CorrespondenceDto>.Failure(ResponseStatus.NotFound);

            return ListResponseBase<CorrespondenceDto>.Success(correspondences);
        }
    }
}
