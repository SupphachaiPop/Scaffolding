using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // specification
    public class specificationConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<specification>
    {
        public specificationConfiguration()
            : this("dbo")
        {
        }

        public specificationConfiguration(string schema)
        {
            ToTable("specification", schema);
            HasKey(x => x.specification_id);

            Property(x => x.specification_id).HasColumnName(@"specification_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.specification_name).HasColumnName(@"specification_name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("date").IsOptional();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("date").IsOptional();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsOptional();
        }
    }

}

