using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // bank_account
    public class bank_accountConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<bank_account>
    {
        public bank_accountConfiguration()
            : this("dbo")
        {
        }

        public bank_accountConfiguration(string schema)
        {
            ToTable("bank_account", schema);
            HasKey(x => x.bank_account_id);

            Property(x => x.bank_account_id).HasColumnName(@"bank_account_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.bank_id).HasColumnName(@"bank_id").HasColumnType("int").IsRequired();
            Property(x => x.account_no).HasColumnName(@"account_no").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.account_name).HasColumnName(@"account_name").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(200);
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.bank).WithMany(b => b.bank_accounts).HasForeignKey(c => c.bank_id).WillCascadeOnDelete(false); // FK_bank_account_bank
        }
    }

}

