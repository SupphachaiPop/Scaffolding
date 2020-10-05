using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // product_stock_image
    public class product_stock_imageConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<product_stock_image>
    {
        public product_stock_imageConfiguration()
            : this("dbo")
        {
        }

        public product_stock_imageConfiguration(string schema)
        {
            ToTable("product_stock_image", schema);
            HasKey(x => x.product_stock_image_id);

            Property(x => x.product_stock_image_id).HasColumnName(@"product_stock_image_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.product_stock_id).HasColumnName(@"product_stock_id").HasColumnType("int").IsRequired();
            Property(x => x.order_image).HasColumnName(@"order_image").HasColumnType("int").IsRequired();
            Property(x => x.image_url).HasColumnName(@"image_url").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsRequired();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.product_stock).WithMany(b => b.product_stock_images).HasForeignKey(c => c.product_stock_id).WillCascadeOnDelete(false); // FK_product_stock_image_product_stock
        }
    }

}

