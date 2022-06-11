namespace ContractManager.Service.Classes
{
    public class ContractService : DomainService<Contract, ContractDto>, IContractService
    {
        private readonly IQueryRepository<Contract> _queryRepository;
        private readonly ICommandRepository<Contract> _commandRepository;
        private readonly IBaseAdapter<Contract, ContractDto> _baseAdapter;

        public ContractService(IQueryRepository<Contract> queryRepository,
            ICommandRepository<Contract> commandRepository,
            IBaseAdapter<Contract, ContractDto> baseAdapter)
            : base(queryRepository, commandRepository, baseAdapter)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _baseAdapter = baseAdapter;
        }
    }
}
