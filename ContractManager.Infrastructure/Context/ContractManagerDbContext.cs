namespace ContractManager.Infrastructure.Context
{
    public class ContractManagerDbContext : DbContext
    {
        public ContractManagerDbContext(DbContextOptions<ContractManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Contract>? Contracts { get; set; }
        public DbSet<Correspondence>? Correspondences { get; set; }
        public DbSet<ContractFile>? ContractFiles { get; set; }
        public DbSet<FundingResource>? FundingResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Correspondence>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ContractFile>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<FundingResource>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
