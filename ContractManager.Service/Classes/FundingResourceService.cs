namespace ContractManager.Service.Classes
{
    public class FundingResourceService : DomainService<FundingResource, FundingResourceDto>, IFundingResourceService
    {
        private readonly IQueryRepository<FundingResource> _queryRepository;
        private readonly ICommandRepository<FundingResource> _commandRepository;
        private readonly IBaseAdapter<FundingResource, FundingResourceDto> _baseAdapter;

        public FundingResourceService(IQueryRepository<FundingResource> queryRepository,
            ICommandRepository<FundingResource> commandRepository,
            IBaseAdapter<FundingResource, FundingResourceDto> baseAdapter)
            : base(queryRepository, commandRepository, baseAdapter)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _baseAdapter = baseAdapter;
        }

        public async Task<int> GetCountById(int contractId)
        {
            var result = await _queryRepository.GetAsync(x => x.ContractId == contractId);
            return result.Count;
        }

        public async Task<List<FundingResourceDto>> GetAllByContractId(int contractId)
        {
            var result = await _queryRepository.GetAsync(x => x.ContractId == contractId);
            return _baseAdapter.GetDtos(result).ToList();
        }
    }
}
