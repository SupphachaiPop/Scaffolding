using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // symptom
    public class symptomConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<symptom>
    {
        public symptomConfiguration()
            : this("dbo")
        {
        }

        public symptomConfiguration(string schema)
        {
            ToTable("symptom", schema);
            HasKey(x => x.symptom_id);

            Property(x => x.symptom_id).HasColumnName(@"symptom_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.symptom_code).HasColumnName(@"symptom_code").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.symptom_name).HasColumnName(@"symptom_name").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(300);
            Property(x => x.comment).HasColumnName(@"comment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.created_by).HasColumnName(@"created_by").HasColumnType("int").IsRequired();
            Property(x => x.created_date).HasColumnName(@"created_date").HasColumnType("datetime").IsRequired();
            Property(x => x.modified_by).HasColumnName(@"modified_by").HasColumnType("int").IsRequired();
            Property(x => x.modified_date).HasColumnName(@"modified_date").HasColumnType("datetime").IsRequired();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_deleted).HasColumnName(@"is_deleted").HasColumnType("bit").IsRequired();
        }
    }

}

