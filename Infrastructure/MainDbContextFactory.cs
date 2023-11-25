using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure;

public class MainDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog = Redis;Integrated Security = true; TrustServerCertificate=True");
        var context = new MainDbContext(optionsBuilder.Options);
        return context;
    }
}
