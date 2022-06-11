namespace ContractManager.Share.Adapters
{
    public class ContractAdapter : IBaseAdapter<Contract, ContractDto>
    {
        public ContractDto GetDto(Contract model)
        {
            if (model == null)
                return null;
            return new ContractDto()
            {
                Id = model.Id,
                IsDeleted = model.IsDeleted,
                ContractSide = model.ContractSide,
                ContractStatus = model.ContractStatus,
                ContractType = model.ContractType,
                Cost = model.Cost,
                DueDate = model.DueDate,
                FinalCost = model.FinalCost,
                Number = model.Number,
                PaymentType = model.PaymentType,
                StartDate = model.StartDate,
                Subject = model.Subject
            };
        }

        public IEnumerable<ContractDto> GetDtos(List<Contract> models)
        {
            foreach (var item in models)
            {
                if (item == null)
                    continue;
                yield return GetDto(item);
            }
        }

        public Contract GetModel(ContractDto dto)
        {
            if (dto == null)
                return null;
            return new Contract()
            {
                Id = dto.Id,
                IsDeleted = dto.IsDeleted,
                ContractSide = dto.ContractSide,
                ContractStatus = dto.ContractStatus,
                ContractType = dto.ContractType,
                Cost = dto.Cost,
                DueDate = dto.DueDate,
                FinalCost = dto.FinalCost,
                Number = dto.Number,
                PaymentType = dto.PaymentType,
                StartDate = dto.StartDate,
                Subject = dto.Subject
            };
        }

        public IEnumerable<Contract> GetModels(List<ContractDto> dtos)
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
