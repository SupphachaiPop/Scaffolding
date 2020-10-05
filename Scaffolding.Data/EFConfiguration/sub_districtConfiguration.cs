using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // sub_district
    public class sub_districtConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<sub_district>
    {
        public sub_districtConfiguration()
            : this("dbo")
        {
        }

        public sub_districtConfiguration(string schema)
        {
            ToTable("sub_district", schema);
            HasKey(x => x.sub_district_id);

            Property(x => x.sub_district_id).HasColumnName(@"sub_district_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.name).HasColumnName(@"name").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.name_en).HasColumnName(@"name_en").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.district_id).HasColumnName(@"district_id").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.district).WithMany(b => b.sub_districts).HasForeignKey(c => c.district_id).WillCascadeOnDelete(false); // FK_sub_district_sub_district
        }
    }

}

