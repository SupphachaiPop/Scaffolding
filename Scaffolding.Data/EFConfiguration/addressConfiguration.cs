using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // address
    public class addressConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<address>
    {
        public addressConfiguration()
            : this("dbo")
        {
        }

        public addressConfiguration(string schema)
        {
            ToTable("address", schema);
            HasKey(x => x.address_id);

            Property(x => x.address_id).HasColumnName(@"address_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.address_).HasColumnName(@"address").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.customer_id).HasColumnName(@"customer_id").HasColumnType("int").IsOptional();
            Property(x => x.province_id).HasColumnName(@"province_id").HasColumnType("int").IsOptional();
            Property(x => x.district_id).HasColumnName(@"district_id").HasColumnType("int").IsOptional();
            Property(x => x.sub_district_id).HasColumnName(@"sub_district_id").HasColumnType("int").IsOptional();
            Property(x => x.postalcode).HasColumnName(@"postalcode").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);

            // Foreign keys
            HasOptional(a => a.customer).WithMany(b => b.addresses).HasForeignKey(c => c.customer_id).WillCascadeOnDelete(false); // FK_address_address
            HasOptional(a => a.district).WithMany(b => b.addresses).HasForeignKey(c => c.district_id).WillCascadeOnDelete(false); // FK_address_District
            HasOptional(a => a.province).WithMany(b => b.addresses).HasForeignKey(c => c.province_id).WillCascadeOnDelete(false); // FK_address_province
            HasOptional(a => a.sub_district).WithMany(b => b.addresses).HasForeignKey(c => c.sub_district_id).WillCascadeOnDelete(false); // FK_address_sub_district
        }
    }

}

