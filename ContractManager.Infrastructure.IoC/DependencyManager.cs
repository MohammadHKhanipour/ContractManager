namespace ContractManager.Infrastructure.IoC
{
    public class DependencyManager
    {
        public static void RegisterAllDependencies(IServiceCollection services, string connectionString)
        {
            RegistereDatabase(services, connectionString);
            RegisterAdapters(services);
            RegisterRepositoies(services);
            RegisterServices(services);
        }
        
        #region Register Database
        private static void RegistereDatabase(IServiceCollection services, string connectionString)
            => services.AddDbContext<ContractManagerDbContext>(options => options.UseSqlServer(connectionString));
        #endregion

        #region Register Adapters
        private static void RegisterAdapters(IServiceCollection services)
        {
            services.AddScoped<IBaseAdapter<Contract, ContractDto>, ContractAdapter>();
            services.AddScoped<IBaseAdapter<Correspondence, CorrespondenceDto>, CorrespondenceAdapter>();
            services.AddScoped<IBaseAdapter<ContractFile, ContractFileDto>, ContractFileAdapter>();
            services.AddScoped<IBaseAdapter<FundingResource, FundingResourceDto>, FundingResourceAdapter>();
        }
        #endregion

        #region Register Repositories
        private static void RegisterRepositoies(IServiceCollection services)
        {
            services.AddScoped<IQueryRepository<Contract>, QueryRepository<Contract>>();
            services.AddScoped<IQueryRepository<Correspondence>, QueryRepository<Correspondence>>();
            services.AddScoped<IQueryRepository<ContractFile>, QueryRepository<ContractFile>>();
            services.AddScoped<IQueryRepository<FundingResource>, QueryRepository<FundingResource>>();

            services.AddScoped<ICommandRepository<Contract>, CommandRepository<Contract>>();
            services.AddScoped<ICommandRepository<Correspondence>, CommandRepository<Correspondence>>();
            services.AddScoped<ICommandRepository<ContractFile>, CommandRepository<ContractFile>>();
            services.AddScoped<ICommandRepository<FundingResource>, CommandRepository<FundingResource>>();
        }
        #endregion

        #region Register Services
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<ICorrespondenceService, CorrespondenceService>();
            services.AddScoped<IContractFileService, ContractFileService>();
            services.AddScoped<IFundingResourceService, FundingResourceService>();
        }
        #endregion
    }
}
