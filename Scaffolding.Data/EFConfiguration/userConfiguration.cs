using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    public class userConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<user>
    {
        public userConfiguration()
                : this("dbo")
        {
        }

        public userConfiguration(string schema)
        {
            // Create Table Description For: Domain 
            // -----------------
            ToTable("user", schema);
            HasKey(x => x.user_id);

            // Create Unique Key & Column Description 
            // -----------------

            // Create Foreign Key
            // ------------------
            HasOptional(a => a.role).WithMany(b => b.user).HasForeignKey(c => c.role_id).WillCascadeOnDelete(false); // FK_address_District

        }
    }

}


