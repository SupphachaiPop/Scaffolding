using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // category
    public class categoryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<category>
    {
        public categoryConfiguration()
            : this("dbo")
        {
        }

        public categoryConfiguration(string schema)
        {
            ToTable("category", schema);
            HasKey(x => x.category_id);

            Property(x => x.category_id).HasColumnName(@"category_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.category_name).HasColumnName(@"category_name").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
        }
    }

}

