namespace ContractManager.Service.Classes
{
    public class ContractFileService : DomainService<ContractFile, ContractFileDto>, IContractFileService
    {
        private readonly IQueryRepository<ContractFile> _queryRepository;
        private readonly ICommandRepository<ContractFile> _commandRepository;
        private readonly IBaseAdapter<ContractFile, ContractFileDto> _baseAdapter;

        public ContractFileService(IQueryRepository<ContractFile> queryRepository, ICommandRepository<ContractFile> commandRepository, IBaseAdapter<ContractFile, ContractFileDto> baseAdapter)
            : base(queryRepository, commandRepository, baseAdapter)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _baseAdapter = baseAdapter;
        }
    }
}
