using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // sale_order_item
    public class sale_order_itemConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<sale_order_item>
    {
        public sale_order_itemConfiguration()
            : this("dbo")
        {
        }

        public sale_order_itemConfiguration(string schema)
        {
            ToTable("sale_order_item", schema);
            HasKey(x => x.sale_order_item_);

            Property(x => x.sale_order_item_).HasColumnName(@"sale_order_item").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.cart_id).HasColumnName(@"cart_id").HasColumnType("int").IsRequired();
            Property(x => x.sale_order_id).HasColumnName(@"sale_order_id").HasColumnType("int").IsRequired();
            Property(x => x.product_stock_id).HasColumnName(@"product_stock_id").HasColumnType("int").IsRequired();
            Property(x => x.price).HasColumnName(@"price").HasColumnType("money").IsRequired().HasPrecision(19,4);
            Property(x => x.qty).HasColumnName(@"qty").HasColumnType("int").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsRequired();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsRequired();

            // Foreign keys
            HasRequired(a => a.cart).WithMany(b => b.sale_order_items).HasForeignKey(c => c.cart_id).WillCascadeOnDelete(false); // FK_sale_order_item_cart
            HasRequired(a => a.product_stock).WithMany(b => b.sale_order_items).HasForeignKey(c => c.product_stock_id).WillCascadeOnDelete(false); // FK_sale_order_item_product_stock
            HasRequired(a => a.sale_order).WithMany(b => b.sale_order_items).HasForeignKey(c => c.sale_order_id).WillCascadeOnDelete(false); // FK_sale_order_item_sale_order
        }
    }

}

