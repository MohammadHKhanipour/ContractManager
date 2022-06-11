namespace ContractManager.Infrastructure.Repositories
{
    public class QueryRepository<Model> : IQueryRepository<Model> where Model : BaseModel
    {
        private readonly ContractManagerDbContext _context;

        public QueryRepository(ContractManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Model> GetAsync(int id)
            => await _context.Set<Model>().FindAsync(id);

        public async Task<List<Model>> GetAsync()
            => await _context.Set<Model>().ToListAsync();

        public async Task<List<Model>> GetAsync(Expression<Func<Model, bool>> expression)
            => await _context.Set<Model>().Where(expression).ToListAsync();

        public async Task<int> GetCountAsync()
            => await _context.Set<Model>().CountAsync();

        public async Task<Model> GetFirstOrDefaultAsync(Expression<Func<Model, bool>> expression)
            => await _context.Set<Model>().Where(expression).FirstOrDefaultAsync();

        public async Task<Model> GetSingleOrDefaultAsync(Expression<Func<Model, bool>> expression)
            => await _context.Set<Model>().Where(expression).SingleOrDefaultAsync();
    }
}
