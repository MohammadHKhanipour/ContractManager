namespace ContractManager.Service.Classes
{
    public class ContractFileService : DomainService<ContractFile, ContractFileDto>, IContractFileService
    {
        private readonly IQueryRepository<ContractFile> _queryRepository;
        private readonly ICommandRepository<ContractFile> _commandRepository;
        private readonly IBaseAdapter<ContractFile, ContractFileDto> _baseAdapter;

        public ContractFileService(IQueryRepository<ContractFile> queryRepository,
            ICommandRepository<ContractFile> commandRepository,
            IBaseAdapter<ContractFile, ContractFileDto> baseAdapter)
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

        public async Task<List<ContractFileDto>> GetAllByContractId(int contractId)
        {
            var result = await _queryRepository.GetAsync(x => x.ContractId == contractId);
            return _baseAdapter.GetDtos(result).ToList();
        }
    }
}
