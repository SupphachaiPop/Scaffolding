using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // cart
    public class cartConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<cart>
    {
        public cartConfiguration()
            : this("dbo")
        {
        }

        public cartConfiguration(string schema)
        {
            ToTable("cart", schema);
            HasKey(x => x.cart_id);

            Property(x => x.cart_id).HasColumnName(@"cart_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.customer_id).HasColumnName(@"customer_id").HasColumnType("int").IsRequired();
            Property(x => x.product_stock_id).HasColumnName(@"product_stock_id").HasColumnType("int").IsRequired();
            Property(x => x.is_in_order).HasColumnName(@"is_in_order").HasColumnType("bit").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.customer).WithMany(b => b.carts).HasForeignKey(c => c.customer_id).WillCascadeOnDelete(false); // FK_cart_customer
            HasRequired(a => a.product_stock).WithMany(b => b.carts).HasForeignKey(c => c.product_stock_id).WillCascadeOnDelete(false); // FK_cart_product_stock
        }
    }

}

