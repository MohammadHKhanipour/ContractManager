namespace ContractManager.Infrastructure.Context
{
    public class ContractManagerDbContext : DbContext
    {
        public ContractManagerDbContext(DbContextOptions<ContractManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Contract>? Contracts { get; set; }
        public DbSet<Correspondence>? Correspondences { get; set; }
        public DbSet<Documentation>? Documentations { get; set; }
        public DbSet<FundingResource>? FundingResources { get; set; }
    }
}
