namespace ContractManager.Infrastructure.IoC
{
    public class DependencyManager
    {
        #region Register Database
        public static void RegistereDatabase(IServiceCollection services, string connectionString)
            => services.AddDbContext<ContractManagerDbContext>(options => options.UseSqlServer(connectionString));
        #endregion

        #region Register Adapters
        public static void RegisterAdapters(IServiceCollection services)
        {
            services.AddScoped<IBaseAdapter<Contract, ContractDto>, ContractAdapter>();
            services.AddScoped<IBaseAdapter<Correspondence, CorrespondenceDto>, CorrespondenceAdapter>();
            services.AddScoped<IBaseAdapter<Documentation, DocumentationDto>, DocumentationAdapter>();
            services.AddScoped<IBaseAdapter<FundingResource, FundingResourceDto>, FundingResourceAdapter>();
        }
        #endregion

        #region Register Repositories
        public static void RegisterRepositoies(IServiceCollection services)
        {
            services.AddScoped<IQueryRepository<Contract>, QueryRepository<Contract>>();
            services.AddScoped<IQueryRepository<Correspondence>, QueryRepository<Correspondence>>();
            services.AddScoped<IQueryRepository<Documentation>, QueryRepository<Documentation>>();
            services.AddScoped<IQueryRepository<FundingResource>, QueryRepository<FundingResource>>();
        }
        #endregion
    }
}
