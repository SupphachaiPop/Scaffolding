using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // product_image
    public class product_imageConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<product_image>
    {
        public product_imageConfiguration()
            : this("dbo")
        {
        }

        public product_imageConfiguration(string schema)
        {
            ToTable("product_image", schema);
            HasKey(x => x.product_image_id);

            Property(x => x.product_image_id).HasColumnName(@"product_image_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.product_id).HasColumnName(@"product_id").HasColumnType("int").IsOptional();
            Property(x => x.url).HasColumnName(@"url").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsOptional();

            // Foreign keys
            HasOptional(a => a.product).WithMany(b => b.product_images).HasForeignKey(c => c.product_id).WillCascadeOnDelete(false); // FK_product_image_product
        }
    }

}

