using ContractManager.Infrastructure.Context;
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
    }
}
