using DLL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public static class DLLDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(optionsAction: option =>
                option.UseSqlServer(configuration.GetConnectionString(name:"DefaultConnection")));
        }
    }
}