namespace ContractManager.Infrastructure.Repositories
{
    public interface ICommandRepository<Model> where Model : BaseModel
    {
        public Task<bool> AddAsync(Model entity);
        public Task<bool> AddRangeAsync(List<Model> entities);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> DeleteAsync(Model entity);
        public Task<bool> DeleteRangeAsync(List<Model> entities);
        public Task<bool> UpdateAsync(Model entity);
    }
}
