namespace ContractManager.Business.Interfaces
{
    public interface IContractBusiness : IDomainBusiness<Contract, ContractDto>
    {
        Task<ListResponseBase<ShowContractDto>> GetAllContracts();
    }
}
