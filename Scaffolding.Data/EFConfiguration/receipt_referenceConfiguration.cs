using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // receipt_reference
    public class receipt_referenceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<receipt_reference>
    {
        public receipt_referenceConfiguration()
            : this("dbo")
        {
        }

        public receipt_referenceConfiguration(string schema)
        {
            ToTable("receipt_reference", schema);
            HasKey(x => x.receipt_id);

            Property(x => x.receipt_id).HasColumnName(@"receipt_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.receipt_no).HasColumnName(@"receipt_no").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.sale_order_id).HasColumnName(@"sale_order_id").HasColumnType("int").IsRequired();
            Property(x => x.customer_id).HasColumnName(@"customer_id").HasColumnType("int").IsRequired();
            Property(x => x.receipt_date).HasColumnName(@"receipt_date").HasColumnType("datetime").IsRequired();
            Property(x => x.transfer_date).HasColumnName(@"transfer_date").HasColumnType("datetime").IsRequired();
            Property(x => x.transfer_time).HasColumnName(@"transfer_time").HasColumnType("time").IsRequired();
            Property(x => x.transfer_amount).HasColumnName(@"transfer_amount").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.bank_account_id).HasColumnName(@"bank_account_id").HasColumnType("int").IsRequired();
            Property(x => x.source_bank_id).HasColumnName(@"source_bank_id").HasColumnType("int").IsRequired();
            Property(x => x.remark).HasColumnName(@"remark").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(300);
            Property(x => x.admin_id).HasColumnName(@"admin_id").HasColumnType("int").IsRequired();
            Property(x => x.status).HasColumnName(@"status").HasColumnType("int").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.bank).WithMany(b => b.receipt_references).HasForeignKey(c => c.source_bank_id).WillCascadeOnDelete(false); // FK_receipt_reference_bank
            HasRequired(a => a.bank_account).WithMany(b => b.receipt_references).HasForeignKey(c => c.bank_account_id).WillCascadeOnDelete(false); // FK_receipt_reference_bank_account
            HasRequired(a => a.sale_order).WithMany(b => b.receipt_references).HasForeignKey(c => c.sale_order_id).WillCascadeOnDelete(false); // FK_receipt_reference_sale_order
        }
    }

}

