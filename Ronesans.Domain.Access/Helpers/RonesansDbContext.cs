using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Ronesans.Domain.Concrete.Domain;

namespace Ronesans.Domain.Access.Helpers
{
    public class RonesansDbContext : DbContext
    {
        public RonesansDbContext(DbContextOptions<RonesansDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                .Property(b => b.status_active)
                .HasDefaultValue(true);
            modelBuilder.Entity<User>()
              .Property(b => b.status_visibility)
              .HasDefaultValue(true);
            modelBuilder.Entity<User>()
               .Property(b => b.gender_id)
               .HasDefaultValue(1);
            modelBuilder.Entity<User>()
              .Property(b => b.role_id)
              .HasDefaultValue(2);
            modelBuilder.Entity<User>()
                .Property(t => t.user_id)
                .HasColumnType("int");
            //user finish
            //shop
            modelBuilder.Entity<Shop>()
            .Property(b => b.currency_code)
            .HasDefaultValue("TRY");
            modelBuilder.Entity<Shop>()
             .Property(b => b.status_active)
             .HasDefaultValue(true);
            modelBuilder.Entity<Shop>()
              .Property(b => b.status_visibility)
              .HasDefaultValue(true);
            //shop finish

            //file
            modelBuilder.Entity<File>()
                .Property(t => t.file_id)
                .HasColumnType("int");
            //file finish

            //Userfile
            modelBuilder.Entity<UserFile>()
                .Property(t => t.user_id)
                .HasColumnType("int");
            modelBuilder.Entity<UserFile>()
                .Property(t => t.file_id)
                .HasColumnType("int");
            modelBuilder.Entity<UserFile>()
         .HasKey(bc => new { bc.user_id, bc.file_id });
            modelBuilder.Entity<UserFile>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserFiles)
                .HasForeignKey(bc => bc.user_id);
            modelBuilder.Entity<UserFile>()
                .HasOne(bc => bc.File)
                .WithMany(c => c.UserFiles)
                .HasForeignKey(bc => bc.file_id);
            //Userfile finish

            //ShopFile
            modelBuilder.Entity<ShopFile>()
                .Property(t => t.shop_id)
                .HasColumnType("int");
            modelBuilder.Entity<ShopFile>()
                .Property(t => t.file_id)
                .HasColumnType("int");
            modelBuilder.Entity<ShopFile>()
         .HasKey(bc => new { bc.shop_id, bc.file_id });
            modelBuilder.Entity<ShopFile>()
                .HasOne(bc => bc.Shop)
                .WithMany(b => b.ShopFiles)
                .HasForeignKey(bc => bc.shop_id);
            modelBuilder.Entity<ShopFile>()
                .HasOne(bc => bc.File)
                .WithMany(c => c.ShopFiles)
                .HasForeignKey(bc => bc.file_id);
            //ShopFile finish
        }
        public DbSet<Shop> Shops { get; set; }
        //public DbSet<Announcement> Announcements { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<ShopFile> ShopFiles { get; set; }

    }
}
