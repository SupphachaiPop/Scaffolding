using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // refund_reference
    public class refund_referenceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<refund_reference>
    {
        public refund_referenceConfiguration()
            : this("dbo")
        {
        }

        public refund_referenceConfiguration(string schema)
        {
            ToTable("refund_reference", schema);
            HasKey(x => x.refund_id);

            Property(x => x.refund_id).HasColumnName(@"refund_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.refund_no).HasColumnName(@"refund_no").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.sale_order_id).HasColumnName(@"sale_order_id").HasColumnType("int").IsRequired();
            Property(x => x.receipt_id).HasColumnName(@"receipt_id").HasColumnType("int").IsRequired();
            Property(x => x.bank_account_id).HasColumnName(@"bank_account_id").HasColumnType("int").IsRequired();
            Property(x => x.customer_id).HasColumnName(@"customer_id").HasColumnType("int").IsRequired();
            Property(x => x.cust_bank_id).HasColumnName(@"cust_bank_id").HasColumnType("int").IsRequired();
            Property(x => x.cust_account_no).HasColumnName(@"cust_account_no").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.payment_date).HasColumnName(@"payment_date").HasColumnType("datetime").IsRequired();
            Property(x => x.payment_amount).HasColumnName(@"payment_amount").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.admin_id).HasColumnName(@"admin_id").HasColumnType("int").IsRequired();
            Property(x => x.status).HasColumnName(@"status").HasColumnType("int").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.bank).WithMany(b => b.refund_references).HasForeignKey(c => c.cust_bank_id).WillCascadeOnDelete(false); // FK_refund_reference_bank
        }
    }

}

