using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack_Project_IE_2.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set;}
        public DbSet<Type> Types { get; set;}
        public DbSet<Dancer> Dancers { get; set;}
        public DbSet<Couple> Couples { get; set;}
        public DbSet<Competition> Competitions { get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserType>().HasKey(q=>new { q.UserId, q.TypeId});
            
            builder.Entity<Dancer>().HasKey(p=>p.Id);
            builder.Entity<Dancer>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Dancer>().Property(p=>p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Dancer>().Property(p=>p.role).IsRequired();
            builder.Entity<Dancer>().Property(p=>p.ST).IsRequired();
            builder.Entity<Dancer>().Property(p=>p.LA).IsRequired();
            builder.Entity<Dancer>().Property(p=>p.PointsLA).IsRequired();
            builder.Entity<Dancer>().Property(p=>p.PointsST).IsRequired();
           
            builder.Entity<Couple>().HasKey(p=>p.Id);
            builder.Entity<Couple>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Couple>().HasMany(c=>c.Dancers).WithOne(v=>v.Couple);

            builder.Entity<Competition>().HasKey(p=>p.Id);
            builder.Entity<Competition>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Competition>().Property(p => p.Location).IsRequired().HasMaxLength(30);

        }

    }
}
