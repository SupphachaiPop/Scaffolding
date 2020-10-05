using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // product_specification
    public class product_specificationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<product_specification>
    {
        public product_specificationConfiguration()
            : this("dbo")
        {
        }

        public product_specificationConfiguration(string schema)
        {
            ToTable("product_specification", schema);
            HasKey(x => x.product_specification_id);

            Property(x => x.product_specification_id).HasColumnName(@"product_specification_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.sub_specification_id).HasColumnName(@"sub_specification_id").HasColumnType("int").IsOptional();
            Property(x => x.product_id).HasColumnName(@"product_id").HasColumnType("int").IsOptional();
            Property(x => x.value).HasColumnName(@"value").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("date").IsOptional();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("date").IsOptional();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsOptional();

            // Foreign keys
            HasOptional(a => a.product).WithMany(b => b.product_specifications).HasForeignKey(c => c.product_id).WillCascadeOnDelete(false); // FK_product_specification_product1
            HasOptional(a => a.sub_specification).WithMany(b => b.product_specifications).HasForeignKey(c => c.sub_specification_id).WillCascadeOnDelete(false); // FK_product_specification_product
        }
    }

}

