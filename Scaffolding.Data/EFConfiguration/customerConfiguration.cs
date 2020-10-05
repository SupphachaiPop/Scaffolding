using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // customer
    public class customerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<customer>
    {
        public customerConfiguration()
            : this("dbo")
        {
        }

        public customerConfiguration(string schema)
        {
            ToTable("customer", schema);
            HasKey(x => x.customer_id);

            Property(x => x.customer_id).HasColumnName(@"customer_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.salutation).HasColumnName(@"salutation").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.firstname).HasColumnName(@"firstname").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.lastname).HasColumnName(@"lastname").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.gender).HasColumnName(@"gender").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.dateofbirth).HasColumnName(@"dateofbirth").HasColumnType("date").IsOptional();
            Property(x => x.shipping_address_id).HasColumnName(@"shipping_address_id").HasColumnType("int").IsOptional();
            Property(x => x.billing_address_id).HasColumnName(@"billing_address_id").HasColumnType("int").IsOptional();
            Property(x => x.phone).HasColumnName(@"phone").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(10);
            Property(x => x.email).HasColumnName(@"email").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.picture).HasColumnName(@"picture").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.tax_id_number).HasColumnName(@"tax_id_number").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(30);
            Property(x => x.password).HasColumnName(@"password").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsOptional();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsOptional();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsOptional();
            Property(x => x.type).HasColumnName(@"type").HasColumnType("int").IsOptional();
            Property(x => x.is_person).HasColumnName(@"is_person").HasColumnType("bit").IsOptional();
        }
    }

}

