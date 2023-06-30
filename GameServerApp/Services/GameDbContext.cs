using Microsoft.EntityFrameworkCore;
using SharedLibrary;

namespace GameServerApp.Services;

public class GameDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var connectionString = "server=localhost;user=codthomp;password=flat 17 rocket;database=firstapp";

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) {

    }

    public DbSet<User> Users { get; set;}
    public DbSet<Hero> Hero { get; set;}
}
