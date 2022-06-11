using ContractManager.Domain.Models;
using ContractManager.Framework.Adapter;
using ContractManager.Infrastructure.Context;
using ContractManager.Share.Adapters;
using ContractManager.Share.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
