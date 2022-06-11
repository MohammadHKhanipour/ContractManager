using ContractManager.Framework.Contracts;
using ContractManager.Framework.Data;
using ContractManager.Framework.Enums;

namespace ContractManager.Business.Classes
{
    public class DomainBusiness<Model, Dto> : IDomainBusiness<Model, Dto> where Model : BaseModel where Dto : BaseDto
    {
        private readonly IDomainService<Model, Dto> _domainService;

        public DomainBusiness(IDomainService<Model, Dto> domainService)
        {
            _domainService = domainService;
        }

        public async Task<ResponseBase<bool>> AddAsync(Dto entity)
        {
            var result = await _domainService.AddAsync(entity);

            if (result)
                return ResponseBase<bool>.Success(true);
            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }

        public async Task<ResponseBase<bool>> AddRangeAsync(List<Dto> entities)
        {
            var result = await _domainService.AddRangeAsync(entities);

            if (result)
                return ResponseBase<bool>.Success(true);
            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }

        public async Task<ResponseBase<bool>> DeleteAsync(int id)
        {
            var result = await _domainService.DeleteAsync(id);

            if (result)
                return ResponseBase<bool>.Success(true);
            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }

        public async Task<ResponseBase<bool>> DeleteAsync(Dto entity)
        {
            var result = await _domainService.DeleteAsync(entity);

            if (result)
                return ResponseBase<bool>.Success(true);
            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }

        public async Task<ResponseBase<bool>> DeleteRangeAsync(List<Dto> entities)
        {
            var result = await _domainService.DeleteRangeAsync(entities);

            if (result)
                return ResponseBase<bool>.Success(true);
            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }

        public async Task<ResponseBase<Dto>> GetAsync(int id)
        {
            var result = await _domainService.GetAsync(id);

            if (result != null)
                return ResponseBase<Dto>.Success(result);
            return ResponseBase<Dto>.Failure(ResponseStatus.NotFound);
        }

        public async Task<ListResponseBase<Dto>> GetAsync()
        {
            var result = await _domainService.GetAsync();

            if (result != null && result.Any())
                return ListResponseBase<Dto>.Success(result);
            return ListResponseBase<Dto>.Failure(ResponseStatus.NotFound);
        }

        public async Task<ResponseBase<int>> GetCountAsync()
        {
            var result = await _domainService.GetCountAsync();

            return ResponseBase<int>.Success(result);
        }

        public async Task<ResponseBase<bool>> UpdateAsync(Dto entity)
        {
            var result = await _domainService.UpdateAsync(entity);

            if (result)
                return ResponseBase<bool>.Success(true);
            return ResponseBase<bool>.Failure(ResponseStatus.Fail);
        }
    }
}
