using CookieStandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CookieStandApi.Data
{
    public class CookieStandDBContext : DbContext
    {
        public CookieStandDBContext(DbContextOptions<CookieStandDBContext> options) : base(options)
        {

        }

        public DbSet<CookieStand> CookieStands { get; set; }
        public DbSet<HourlySale> hourlySales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CookieStand>()
            .HasMany(c => c.hourlySale)
            .WithOne(h => h.CookieStand)
            .HasForeignKey(h => h.CookieStandId);
        } 
        

    }
}
