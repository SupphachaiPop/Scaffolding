using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // product
    public class productConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<product>
    {
        public productConfiguration()
            : this("dbo")
        {
        }

        public productConfiguration(string schema)
        {
            ToTable("product", schema);
            HasKey(x => x.product_id);

            Property(x => x.product_id).HasColumnName(@"product_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.sku).HasColumnName(@"sku").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.product_name).HasColumnName(@"product_name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.overview).HasColumnName(@"overview").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.description).HasColumnName(@"description").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.cost).HasColumnName(@"cost").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.retail_price).HasColumnName(@"retail_price").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.web_price).HasColumnName(@"web_price").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.feature_picture).HasColumnName(@"feature_picture").HasColumnType("int").IsOptional();
            Property(x => x.brand_id).HasColumnName(@"brand_id").HasColumnType("int").IsOptional();
            Property(x => x.category_id).HasColumnName(@"category_id").HasColumnType("int").IsOptional();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("date").IsOptional();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("date").IsOptional();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsOptional();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsOptional();

            // Foreign keys
            HasOptional(a => a.brand).WithMany(b => b.products).HasForeignKey(c => c.brand_id).WillCascadeOnDelete(false); // FK_product_brand
            HasOptional(a => a.category).WithMany(b => b.products).HasForeignKey(c => c.category_id).WillCascadeOnDelete(false); // FK_product_category
        }
    }

}

