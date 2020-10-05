using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // province
    public class provinceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<province>
    {
        public provinceConfiguration()
            : this("dbo")
        {
        }

        public provinceConfiguration(string schema)
        {
            ToTable("province", schema);
            HasKey(x => x.province_id);

            Property(x => x.province_id).HasColumnName(@"province_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.name).HasColumnName(@"name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.name_en).HasColumnName(@"name_en").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
        }
    }

}

