using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // sale_order
    public class sale_orderConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<sale_order>
    {
        public sale_orderConfiguration()
            : this("dbo")
        {
        }

        public sale_orderConfiguration(string schema)
        {
            ToTable("sale_order", schema);
            HasKey(x => x.sale_order_id);

            Property(x => x.sale_order_id).HasColumnName(@"sale_order_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.sale_order_no).HasColumnName(@"sale_order_no").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.sale_order_date).HasColumnName(@"sale_order_date").HasColumnType("datetime").IsRequired();
            Property(x => x.sub_total).HasColumnName(@"sub_total").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.discount).HasColumnName(@"discount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.grand_total).HasColumnName(@"grand_total").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.customer_id).HasColumnName(@"customer_id").HasColumnType("int").IsRequired();
            Property(x => x.shipping_address).HasColumnName(@"shipping_address").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.billing_address).HasColumnName(@"billing_address").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.status).HasColumnName(@"status").HasColumnType("int").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();
        }
    }

}

