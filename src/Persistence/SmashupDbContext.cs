using Microsoft.EntityFrameworkCore;
using Smashup.Domain.Modules.Bets;
using Smashup.Domain.Modules.Colors;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.Modules.Users;

namespace Smashup.Persistence
{
  public class SmashupDbContext : DbContext
  {
    public string DbPath { get; }

    public SmashupDbContext(DbContextOptions<SmashupDbContext> options) : base(options)
    {
      var folder = Environment.SpecialFolder.LocalApplicationData;
      var path = Environment.GetFolderPath(folder);
      this.DbPath = System.IO.Path.Join(path, "smashup.db");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmashupDbContext).Assembly);

      // convenationals
      modelBuilder.Entity<User>().ToTable("users");
      modelBuilder.Entity<Color>().ToTable("colors");
      modelBuilder.Entity<Round>().ToTable("rounds");
      modelBuilder.Entity<Bet>().ToTable("bets");

      // relations
      modelBuilder.Entity<Round>().HasOne(round => round.color);
      modelBuilder.Entity<Bet>().HasOne(bet => bet.round);

      // uuids
      modelBuilder.Entity<User>().Property<string>(user => user.id).HasColumnType("uuid").ValueGeneratedOnAdd();
      modelBuilder.Entity<Color>().Property<string>(color => color.id).HasColumnType("uuid").ValueGeneratedOnAdd();
      modelBuilder.Entity<Round>().Property<string>(round => round.id).HasColumnType("uuid").ValueGeneratedOnAdd();
      modelBuilder.Entity<Bet>().Property<string>(bet => bet.id).HasColumnType("uuid").ValueGeneratedOnAdd();

      // enums
      modelBuilder.Entity<Bet>()
        .Property(bet => bet.status)
        .HasConversion(
          status => status.ToString(),
          status => (BetStatus)Enum.Parse(typeof(BetStatus), status)
      );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<User> User { get; set; }
    public DbSet<Color> Color { get; set; }
    public DbSet<Round> Round { get; set; }
    public DbSet<Bet> Bet { get; set; }
  }
}