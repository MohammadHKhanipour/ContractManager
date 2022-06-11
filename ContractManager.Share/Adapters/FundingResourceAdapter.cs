namespace ContractManager.Share.Adapters
{
    public class FundingResourceAdapter : IBaseAdapter<FundingResource, FundingResourceDto>
    {
        public FundingResourceDto GetDto(FundingResource model)
        {
            if (model == null)
                return null;
            return new FundingResourceDto()
            {
                Id = model.Id,
                IsDeleted = model.IsDeleted,
                ContractId = model.ContractId,
                Fund = model.Fund,
                Ownership = model.Ownership
            };
        }

        public IEnumerable<FundingResourceDto> GetDtos(List<FundingResource> models)
        {
            foreach (var item in models)
            {
                if (item == null)
                    continue;
                yield return GetDto(item);
            }
        }

        public FundingResource GetModel(FundingResourceDto dto)
        {
            if (dto == null)
                return null;
            return new FundingResource()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                ContractId = dto.ContractId,
                Fund = dto.Fund,
                Ownership = dto.Ownership
            };
        }

        public IEnumerable<FundingResource> GetModels(List<FundingResourceDto> dtos)
        {
            foreach (var item in dtos)
            {
                if (item == null)
                    continue;
                yield return GetModel(item);
            }
        }
    }
}
