using FullStack_Project_IE_2.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack_Project_IE_2.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set;}
        public DbSet<Couple> Couples { get; set;}
        public DbSet<Competition> Competitions { get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>().HasKey(p=>p.Id);
            builder.Entity<User>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p=>p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p=>p.role).IsRequired();
            builder.Entity<User>().Property(p=>p.ST).IsRequired();
            builder.Entity<User>().Property(p=>p.LA).IsRequired();
            builder.Entity<User>().Property(p=>p.PointsLA).IsRequired();
            builder.Entity<User>().Property(p=>p.PointsST).IsRequired();
            builder.Entity<User>().HasOne(p=>p.Couple).WithMany(p=>p.Dancers).HasForeignKey(p=>p.CoupleId);
            
            builder.Entity<User>().HasData(
                new User { Id = 1000, Name = "Jan", role = ERole.Ordinary, ST = EClass.F, LA = EClass.F, PointsLA = 0, PointsST = 0 }
                );

            builder.Entity<Couple>().HasKey(p=>p.Id);
            builder.Entity<Couple>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Couple>().HasMany(p=>p.Dancers).WithOne(p=>p.Couple).HasForeignKey(p=>p.CoupleId);

            builder.Entity<Couple>().HasData(
                new Couple { Id = 1}
                );

            builder.Entity<Competition>().HasKey(p=>p.Id);
            builder.Entity<Competition>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Competition>().Property(p => p.Location).IsRequired().HasMaxLength(30);


        }

    }
}
