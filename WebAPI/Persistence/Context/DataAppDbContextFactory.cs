using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAPI.Persistence.Context
{
    public class DataAppDbContextFactory : IDesignTimeDbContextFactory<DataAppDbContext>
    {
        public DataAppDbContext CreateDbContext(string[] args)
        {

            var options = new DbContextOptionsBuilder<DataAppDbContext>();
            options.UseNpgsql("User ID=postgres;Password=1234;Host=;Port=5432;Database=Banco;");
            return new DataAppDbContext(options.Options, null);
        }
    }
}
