using Microsoft.EntityFrameworkCore;
using PestFree.Models;

namespace PestFree.Data
{
  public class AppDbContextcs:DbContext
  {

    public AppDbContextcs(DbContextOptions<AppDbContextcs> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Floor> Floors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}
