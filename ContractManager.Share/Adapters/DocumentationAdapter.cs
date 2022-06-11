namespace ContractManager.Share.Adapters
{
    public class DocumentationAdapter : IBaseAdapter<Documentation, DocumentationDto>
    {
        public DocumentationDto GetDto(Documentation model)
        {
            if (model == null)
                return null;
            return new DocumentationDto()
            {
                Id = model.Id,
                IsDeleted = model.IsDeleted,
                Name = model.Name,
                ContractId = model.ContractId
            };
        }

        public IEnumerable<DocumentationDto> GetDtos(List<Documentation> models)
        {
            foreach (var item in models)
            {
                if (item == null)
                    continue;
                yield return GetDto(item);
            }
        }

        public Documentation GetModel(DocumentationDto dto)
        {
            if (dto == null)
                return null;
            return new Documentation()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                Name = dto.Name,
                ContractId = dto.ContractId
            };
        }

        public IEnumerable<Documentation> GetModels(List<DocumentationDto> dtos)
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
