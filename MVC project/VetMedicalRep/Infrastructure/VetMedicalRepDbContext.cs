using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class VetMedicalRepDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<VisitProduct> VisitProducts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public VetMedicalRepDbContext(DbContextOptions<VetMedicalRepDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Here you can add logic to handle domain events, auditing, etc. before saving changes.
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Manager>().ToTable("Managers");
            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            });

            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.VisitProducts).WithOne(vp => vp.Product).HasForeignKey(vp => vp.ProductId);
            });

            modelBuilder.Entity<Inventory>().ToTable("Inventories");
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Visit>().ToTable("Visits");
            modelBuilder.Entity<Visit>(entity =>
            {
                entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
                entity.HasMany(e => e.VisitProducts).WithOne(vp => vp.Visit).HasForeignKey(vp => vp.VisitId);
            });

            modelBuilder.Entity<VisitProduct>().ToTable("VisitProducts");
            modelBuilder.Entity<VisitProduct>(entity =>
            {
                entity.HasKey(e => new { e.VisitId, e.ProductId });
                entity.Property(e => e.Quantity).IsRequired();
                entity.HasOne(vp => vp.Visit).WithMany(v => v.VisitProducts).HasForeignKey(vp => vp.VisitId);
                entity.HasOne(vp => vp.Product).WithMany(p => p.VisitProducts).HasForeignKey(vp => vp.ProductId);
            });

            modelBuilder.Entity<User>().ToTable("MedicalRepUsers");
        }
    }
}
