using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // district
    public class districtConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<district>
    {
        public districtConfiguration()
            : this("dbo")
        {
        }

        public districtConfiguration(string schema)
        {
            ToTable("district", schema);
            HasKey(x => x.district_id);

            Property(x => x.district_id).HasColumnName(@"district_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.name).HasColumnName(@"name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.name_en).HasColumnName(@"name_en").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.province_id).HasColumnName(@"province_id").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.province).WithMany(b => b.districts).HasForeignKey(c => c.province_id).WillCascadeOnDelete(false); // FK_District_province
        }
    }

}

