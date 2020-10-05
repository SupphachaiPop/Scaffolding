using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // category_specification
    public class category_specificationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<category_specification>
    {
        public category_specificationConfiguration()
            : this("dbo")
        {
        }

        public category_specificationConfiguration(string schema)
        {
            ToTable("category_specification", schema);
            HasKey(x => x.category_specification_id);

            Property(x => x.category_specification_id).HasColumnName(@"category_specification_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.category_id).HasColumnName(@"category_id").HasColumnType("int").IsOptional();
            Property(x => x.sub_specification_id).HasColumnName(@"sub_specification_id").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.category).WithMany(b => b.category_specifications).HasForeignKey(c => c.category_id).WillCascadeOnDelete(false); // FK_category_specification_category_specification
            HasOptional(a => a.sub_specification).WithMany(b => b.category_specifications).HasForeignKey(c => c.sub_specification_id).WillCascadeOnDelete(false); // FK_category_specification_sub_specification
        }
    }

}

