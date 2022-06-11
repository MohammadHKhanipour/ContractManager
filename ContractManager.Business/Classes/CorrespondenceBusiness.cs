namespace ContractManager.Business.Classes
{
    public class CorrespondenceBusiness : DomainBusiness<Correspondence, CorrespondenceDto>, ICorrespondenceBusiness
    {
        public CorrespondenceBusiness(IDomainService<Correspondence, CorrespondenceDto> domainService) : base(domainService)
        {
        }
    }
}
