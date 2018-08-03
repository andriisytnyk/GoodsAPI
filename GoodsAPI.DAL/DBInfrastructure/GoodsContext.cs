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

        //private readonly ConnectionStringService connectionStringService;

        public GoodsContext(DbContextOptions<GoodsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-5S77NGN; Database = GoodsDB; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            if (Accounts is IEnumerable<TEntity>)
                return Accounts as DbSet<TEntity>;
            else if (Bills is IEnumerable<TEntity>)
                return Bills as DbSet<TEntity>;
            else if (Goods is IEnumerable<TEntity>)
                return Goods as DbSet<TEntity>;
            else if (Importances is IEnumerable<TEntity>)
                return Importances as DbSet<TEntity>;
            else if (GoodTypes is IEnumerable<TEntity>)
                return GoodTypes as DbSet<TEntity>;
            else
                return Users as DbSet<TEntity>;
        }
    }
}