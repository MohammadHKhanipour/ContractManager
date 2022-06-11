namespace ContractManager.Business.Classes
{
    public class ContractBusiness : DomainBusiness<Contract, ContractDto>, IContractBusiness
    {
        public ContractBusiness(IDomainService<Contract, ContractDto> domainService) : base(domainService)
        {
        }
    }
}
