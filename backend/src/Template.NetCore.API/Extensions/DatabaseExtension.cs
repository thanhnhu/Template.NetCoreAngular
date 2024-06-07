using Template.NetCore.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.NetCore.API.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment?.EnvironmentName == "Development")
                services.AddDbContextPool<BookDbContext>(o =>
                {
                    o.UseSqlite("Data Source=test.db");
                });
            else
                services.AddDbContextPool<BookDbContext>(o =>
                {
                    o.UseSqlite("Data Source=test.db");
                    //o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    //o.UseInMemoryDatabase(databaseName: "booksdb");
                });
        }
    }
}
