namespace ContractManager.Service.Interfaces
{
    public interface ICorrespondenceService : IDomainService<Correspondence, CorrespondenceDto>
    {
        Task<int> GetCountById(int contractId);
    }
}
