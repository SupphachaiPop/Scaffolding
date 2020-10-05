using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // brand
    public class brandConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<brand>
    {
        public brandConfiguration()
            : this("dbo")
        {
        }

        public brandConfiguration(string schema)
        {
            ToTable("brand", schema);
            HasKey(x => x.brand_id);

            Property(x => x.brand_id).HasColumnName(@"brand_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.brand_name).HasColumnName(@"brand_name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
        }
    }

}

