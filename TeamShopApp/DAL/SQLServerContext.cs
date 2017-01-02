using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class SQLServerContext : DbContext, IDbContextFactory<SQLServerContext>
    {
        public SQLServerContext(): base("MyConnection"){}

        public SQLServerContext(string constrname): base(constrname){}

        public DbSet<Tovar> Tovars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SQLServerContext>(null);
            //modelBuilder.Entity<Category>().HasMany(s => s.Tovars);
            base.OnModelCreating(modelBuilder);
        }

        public SQLServerContext Create()
        {
            return new SQLServerContext("MyConnection");
        }
    }
}
