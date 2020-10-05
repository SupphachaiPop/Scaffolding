using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // sub_specification
    public class sub_specificationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<sub_specification>
    {
        public sub_specificationConfiguration()
            : this("dbo")
        {
        }

        public sub_specificationConfiguration(string schema)
        {
            ToTable("sub_specification", schema);
            HasKey(x => x.sub_specification_id);

            Property(x => x.sub_specification_id).HasColumnName(@"sub_specification_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.specification_id).HasColumnName(@"specification_id").HasColumnType("int").IsOptional();
            Property(x => x.sub_specification_name).HasColumnName(@"sub_specification_name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("date").IsOptional();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("date").IsOptional();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsOptional();

            // Foreign keys
            HasOptional(a => a.specification).WithMany(b => b.sub_specifications).HasForeignKey(c => c.specification_id).WillCascadeOnDelete(false); // FK_sub_specification_specification
        }
    }

}

