namespace ContractManager.Business.Interfaces
{
    public interface ICorrespondenceBusiness : IDomainBusiness<Correspondence, CorrespondenceDto>
    {
        Task<ListResponseBase<CorrespondenceDto>> GetAllByContractId(int contractId);
    }
}
