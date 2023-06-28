using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DANTN.Data.EF
{
  public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
  {
    public DatabaseContext CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var connectionString = configuration.GetConnectionString("DaisyStudyDb");

      var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
      optionsBuilder.UseSqlServer(connectionString);

      return new DatabaseContext(optionsBuilder.Options);
    }
  }
}