using ContractManager.Framework.Data;
using System.Linq.Expressions;

namespace ContractManager.Framework.Contracts
{
    public interface IDomainBusiness<Model, Dto> where Model : BaseModel where Dto : BaseDto
    {
        public Task<ResponseBase<Dto>> GetAsync(int id);
        public Task<ListResponseBase<Dto>> GetAsync();
        public Task<ResponseBase<int>> GetCountAsync();
        public Task<ResponseBase<bool>> AddAsync(Dto entity);
        public Task<ResponseBase<bool>> AddRangeAsync(List<Dto> entities);
        public Task<ResponseBase<bool>> DeleteAsync(int id);
        public Task<ResponseBase<bool>> DeleteAsync(Dto entity);
        public Task<ResponseBase<bool>> DeleteRangeAsync(List<Dto> entities);
        public Task<ResponseBase<bool>> UpdateAsync(Dto entity);
    }
}
