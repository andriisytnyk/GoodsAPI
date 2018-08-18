using GoodsAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login).IsUnique(true);

            modelBuilder.Entity<UserGoodType>()
                .HasKey(ggt => new { ggt.UserID, ggt.GoodTypeID });
            modelBuilder.Entity<UserGoodType>()
                .HasOne(ggt => ggt.User)
                .WithMany(g => g.UserGoodTypes)
                .HasForeignKey(ggt => ggt.UserID);
            modelBuilder.Entity<UserGoodType>()
                .HasOne(ggt => ggt.GoodType)
                .WithMany(gt => gt.UserGoodTypes)
                .HasForeignKey(ggt => ggt.GoodTypeID);
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
                Users.Load();
                return GoodTypes as DbSet<TEntity>;
            }
            else if (Users is IEnumerable<TEntity>)
            {
                Bills.Load();
                Goods.Load();
                GoodTypes.Load();
                return Users as DbSet<TEntity>;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}