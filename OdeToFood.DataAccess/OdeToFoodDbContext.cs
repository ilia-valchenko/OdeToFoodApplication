using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Entities;

namespace OdeToFood.DataAccess
{
    // We will use LocalDb which comes with Visual Studio.
    // https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli
    // If you don't use Windows machine you can use Docker image for SQL Server.
    // https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash
    public sealed class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}