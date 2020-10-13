using Scaffolding.Models;
using Scaffolding.EFConfiguration;
using System.Data.Entity;

namespace Scaffolding.Data
{
    public class DBEntities : DbContext
    {

        public DBEntities()
            : base(nameOrConnectionString: "ScaffoldingEntities") // value of attribute "name" in <connectionStrings/>
        {
            Database.SetInitializer<DBEntities>(null);
        }

        public DbSet<role> role { get; set; } // role
        public DbSet<role_menu> role_menu { get; set; } // role_menu
        public DbSet<menu> menu { get; set; } // menu
        public DbSet<user> user { get; set; } // user


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new role_menuConfiguration());
            modelBuilder.Configurations.Add(new roleConfiguration());
            modelBuilder.Configurations.Add(new menuConfiguration());
            modelBuilder.Configurations.Add(new userConfiguration());

        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual void CommitAsync()
        {
            base.SaveChangesAsync();
        }
    }
}
