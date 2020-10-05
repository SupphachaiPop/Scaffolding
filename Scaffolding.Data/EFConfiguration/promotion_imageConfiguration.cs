using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // promotion_image
    public class promotion_imageConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<promotion_image>
    {
        public promotion_imageConfiguration()
            : this("dbo")
        {
        }

        public promotion_imageConfiguration(string schema)
        {
            ToTable("promotion_image", schema);
            HasKey(x => x.promotion_image_id);

            Property(x => x.promotion_image_id).HasColumnName(@"promotion_image_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.image_file_name).HasColumnName(@"image_file_name").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.image_url).HasColumnName(@"image_url").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(500);
            Property(x => x.created_date).HasColumnName(@"created_date").HasColumnType("datetime").IsRequired();
            Property(x => x.created_by).HasColumnName(@"created_by").HasColumnType("int").IsRequired();
            Property(x => x.modified_date).HasColumnName(@"modified_date").HasColumnType("datetime").IsOptional();
            Property(x => x.modified_by).HasColumnName(@"modified_by").HasColumnType("int").IsOptional();
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_deleted).HasColumnName(@"is_deleted").HasColumnType("bit").IsRequired();
        }
    }

}

