namespace ContractManager.Business.Classes
{
    public class ContractFileBusiness : DomainBusiness<ContractFile, ContractFileDto>, IContractFileBusiness
    {
        public ContractFileBusiness(IDomainService<ContractFile, ContractFileDto> domainService) : base(domainService)
        {
        }
    }
}
