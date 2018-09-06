using GoodsAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GoodsAPI.DAL.DBInfrastructure
{
    public class GoodsContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Importance> Importances { get; set; }
        public DbSet<GoodType> GoodTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public GoodsContext(DbContextOptions<GoodsContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login).IsUnique(true);

            modelBuilder.Entity<UserImportance>()
                .HasKey(ui => new { ui.UserID, ui.ImportanceID });
            modelBuilder.Entity<UserImportance>()
                .HasOne(ui => ui.User)
                .WithMany(u => u.UserImportances)
                .HasForeignKey(ui => ui.UserID);
            modelBuilder.Entity<UserImportance>()
                .HasOne(ui => ui.Importance)
                .WithMany(gt => gt.UserImportances)
                .HasForeignKey(ui => ui.ImportanceID);

            modelBuilder.Entity<UserGoodType>()
                .HasKey(ugt => new { ugt.UserID, ugt.GoodTypeID });
            modelBuilder.Entity<UserGoodType>()
                .HasOne(ugt => ugt.User)
                .WithMany(u => u.UserGoodTypes)
                .HasForeignKey(ugt => ugt.UserID);
            modelBuilder.Entity<UserGoodType>()
                .HasOne(ugt => ugt.GoodType)
                .WithMany(gt => gt.UserGoodTypes)
                .HasForeignKey(ugt => ugt.GoodTypeID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            if (Accounts is IEnumerable<TEntity>)
            {
                return Accounts as DbSet<TEntity>;
            }
            else if (Bills is IEnumerable<TEntity>)
            {
                Accounts.Load();
                return Bills as DbSet<TEntity>;
            }
            else if (Goods is IEnumerable<TEntity>)
            {
                Importances.Load();
                GoodTypes.Load();
                return Goods as DbSet<TEntity>;
            }
            else if (Importances is IEnumerable<TEntity>)
            {
                return Importances as DbSet<TEntity>;
            }
            else if (GoodTypes is IEnumerable<TEntity>)
            {
                return GoodTypes as DbSet<TEntity>;
            }
            else if (Users is IEnumerable<TEntity>)
            {
                Bills.Load();
                Goods.Load();
                return Users as DbSet<TEntity>;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}