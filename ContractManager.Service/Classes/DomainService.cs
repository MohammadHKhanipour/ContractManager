namespace ContractManager.Service.Classes
{
    public class DomainService<Model, Dto> : IDomainService<Model, Dto> where Model : BaseModel where Dto : BaseDto
    {
        private readonly IQueryRepository<Model> _queryRepository;
        private readonly ICommandRepository<Model> _commandRepository;
        private readonly IBaseAdapter<Model, Dto> _baseAdapter;

        public DomainService(IQueryRepository<Model> queryRepository, ICommandRepository<Model> commandRepository, IBaseAdapter<Model, Dto> baseAdapter)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _baseAdapter = baseAdapter;
        }

        public async Task<Dto> GetAsync(int id)
        {
            var model = await _queryRepository.GetAsync(id);
            return _baseAdapter.GetDto(model);
        }

        public async Task<List<Dto>> GetAsync()
        {
            var models = await _queryRepository.GetAsync();
            return _baseAdapter.GetDtos(models).ToList();
        }

        public async Task<List<Dto>> GetAsync(Expression<Func<Model, bool>> expression)
        {
            var models = await _queryRepository.GetAsync(expression);
            return _baseAdapter.GetDtos(models).ToList();
        }

        public async Task<int> GetCountAsync()
            => await _queryRepository.GetCountAsync();

        public async Task<Dto> GetFirstOrDefaultAsync(Expression<Func<Model, bool>> expression)
        {
            var model = await _queryRepository.GetFirstOrDefaultAsync(expression);
            return _baseAdapter.GetDto(model);
        }

        public async Task<Dto> GetSingleOrDefaultAsync(Expression<Func<Model, bool>> expression)
        {
            var model = await _queryRepository.GetSingleOrDefaultAsync(expression);
            return _baseAdapter.GetDto(model);
        }

        public async Task<bool> AddAsync(Dto entity)
            => await _commandRepository.AddAsync(_baseAdapter.GetModel(entity));

        public async Task<bool> AddRangeAsync(List<Dto> entities)
            => await _commandRepository.AddRangeAsync(_baseAdapter.GetModels(entities).ToList());

        public async Task<bool> DeleteAsync(int id)
            => await _commandRepository.DeleteAsync(id);

        public async Task<bool> DeleteAsync(Dto entity)
            => await _commandRepository.DeleteAsync(_baseAdapter.GetModel(entity));

        public async Task<bool> DeleteRangeAsync(List<Dto> entities)
            => await _commandRepository.DeleteRangeAsync(_baseAdapter.GetModels(entities).ToList());

        public async Task<bool> UpdateAsync(Dto entity)
            => await _commandRepository.UpdateAsync(_baseAdapter.GetModel(entity));

    }
}
