using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task6.BLL.Interfaces;
using Task6.BLL.Interfaces.Services;
using Task6.BLL.Services;
using Task6.DAL.EF;
using Task6.DAL.Interfaces.UnitOfWorks;
using Task6.DAL.UnitOfWorks;

namespace Task6.BLL
{
    public class InjectionResolver
    {
        public static void ConfigureInjections(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StoreContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddScoped<IStoreUnitOfWork, StoreUnitOfWork>();

            services.AddSingleton<ILogService, LogService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ITaskService, TaskService>();
        }
    }
}