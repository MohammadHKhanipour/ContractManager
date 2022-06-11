namespace ContractManager.Share.Adapters
{
    public class CorrespondenceAdapter : IBaseAdapter<Correspondence, CorrespondenceDto>
    {
        public CorrespondenceDto GetDto(Correspondence model)
        {
            if (model == null)
                return null;
            return new CorrespondenceDto()
            {
                Id = model.Id,
                IsDeleted = model.IsDeleted,
                CorrespondenceContent = model.CorrespondenceContent,
                ContractId = model.ContractId,
                CorrespondenceType = model.CorrespondenceType,
            };
        }

        public IEnumerable<CorrespondenceDto> GetDtos(List<Correspondence> models)
        {
            foreach (var item in models)
            {
                if (item == null)
                    continue;
                yield return GetDto(item);
            }
        }

        public Correspondence GetModel(CorrespondenceDto dto)
        {
            if (dto == null)
                return null;
            return new Correspondence()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                CorrespondenceContent = dto.CorrespondenceContent,
                ContractId = dto.ContractId,
                CorrespondenceType = dto.CorrespondenceType
            };
        }

        public IEnumerable<Correspondence> GetModels(List<CorrespondenceDto> dtos)
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
