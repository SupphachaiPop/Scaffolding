using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{    
    // users
    public class userConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<user>
    {
        public userConfiguration()
            : this("dbo")
        {
        }

        public userConfiguration(string schema)
        {
            ToTable("users", schema);
            HasKey(x => x.user_id);

            Property(x => x.user_id).HasColumnName(@"user_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.email).HasColumnName(@"email").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.firstname).HasColumnName(@"firstname").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.lastname).HasColumnName(@"lastname").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.nickname).HasColumnName(@"nickname").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.password).HasColumnName(@"password").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.phone_number).HasColumnName(@"phone_number").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsOptional();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsOptional();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsOptional();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
        }
    }

}

