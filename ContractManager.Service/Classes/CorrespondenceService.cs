namespace ContractManager.Service.Classes
{
    public class CorrespondenceService : DomainService<Correspondence, CorrespondenceDto>, ICorrespondenceService
    {
        private readonly IQueryRepository<Correspondence> _queryRepository;
        private readonly ICommandRepository<Correspondence> _commandRepository;
        private readonly IBaseAdapter<Correspondence, CorrespondenceDto> _baseAdapter;

        public CorrespondenceService(IQueryRepository<Correspondence> queryRepository, ICommandRepository<Correspondence> commandRepository, IBaseAdapter<Correspondence, CorrespondenceDto> baseAdapter)
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
    }
}
