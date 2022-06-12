namespace ContractManager.Service.Interfaces
{
    public interface ICorrespondenceService : IDomainService<Correspondence, CorrespondenceDto>
    {
        Task<List<CorrespondenceDto>> GetAllByContractId(int contractId);
        Task<int> GetCountById(int contractId);
    }
}
