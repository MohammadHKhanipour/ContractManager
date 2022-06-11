namespace ContractManager.Share.Adapters
{
    public class ContractFileAdapter : IBaseAdapter<ContractFile, ContractFileDto>
    {
        public ContractFileDto GetDto(ContractFile model)
        {
            if (model == null)
                return null;
            return new ContractFileDto()
            {
                Id = model.Id,
                IsDeleted = model.IsDeleted,
                Name = model.Name,
                DateAdded = model.DateAdded,
                FileAddress = model.FileAddress,
                ContractId = model.ContractId
            };
        }

        public IEnumerable<ContractFileDto> GetDtos(List<ContractFile> models)
        {
            foreach (var item in models)
            {
                if (item == null)
                    continue;
                yield return GetDto(item);
            }
        }

        public ContractFile GetModel(ContractFileDto dto)
        {
            if (dto == null)
                return null;
            return new ContractFile()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                Name = dto.Name,
                DateAdded = dto.DateAdded,
                FileAddress = dto.FileAddress,
                ContractId = dto.ContractId
            };
        }

        public IEnumerable<ContractFile> GetModels(List<ContractFileDto> dtos)
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
