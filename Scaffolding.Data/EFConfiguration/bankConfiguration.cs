using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // bank
    public class bankConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<bank>
    {
        public bankConfiguration()
            : this("dbo")
        {
        }

        public bankConfiguration(string schema)
        {
            ToTable("bank", schema);
            HasKey(x => x.bank_id);

            Property(x => x.bank_id).HasColumnName(@"bank_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.bank_name).HasColumnName(@"bank_name").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();
        }
    }

}

